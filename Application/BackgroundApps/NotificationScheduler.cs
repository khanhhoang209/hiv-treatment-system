using Application.SignalR;
using Microsoft.AspNetCore.SignalR;
using Repository.Constants;
using Service.Interfaces;

namespace Application.BackgroundApps
{
    public class NotificationScheduler : BackgroundService
    {
        private readonly ILogger<NotificationScheduler> _logger;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IHubContext<NotificationHub> _hub;
        
        private static readonly TimeSpan[] ScheduleTimes =
        {
            new TimeSpan(9, 0, 0),
            new TimeSpan(13, 0, 0),
            new TimeSpan(15, 24, 0),
            new TimeSpan(23, 15, 0)
        };

        public NotificationScheduler(
            ILogger<NotificationScheduler> logger,
            IServiceScopeFactory scopeFactory,
            IHubContext<NotificationHub> hub
            )
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
            _hub = hub;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("NotificationScheduler started.");

            while (!stoppingToken.IsCancellationRequested)
            {
                var now     = DateTimeOffset.Now;
                var nextRun = GetNextSchedule(now);
                var delay   = nextRun - now;

                _logger.LogInformation("Next run at {NextRun}, delaying {Delay}.", nextRun, delay);
                try
                {
                    await Task.Delay(delay, stoppingToken);
                }
                catch (TaskCanceledException)
                {
                    break;
                }
                
                var window = nextRun.TimeOfDay;
                var medTime = window switch
                {
                    _ when window == ScheduleTimes[0] => MedicationTime.Morning,
                    _ when window == ScheduleTimes[1] => MedicationTime.Noon,
                    _ when window == ScheduleTimes[2] => MedicationTime.Evening,
                    _ when window == ScheduleTimes[3] => MedicationTime.Night,
                    _ => throw new InvalidOperationException(
                        $"Unexpected schedule time: {window}")
                };
                
                using var scope = _scopeFactory.CreateScope();
                var notificationService = scope.ServiceProvider
                    .GetRequiredService<INotificationService>();

                try
                {
                    _logger.LogInformation("Sending notifications at {Time}.", DateTimeOffset.Now);
                    await notificationService.CreateMedicationNotificationsAsync(medTime);
                    _logger.LogInformation("Notifications sent successfully.");
                    await _hub.Clients.All.SendAsync("MedicationTimeNotificationTriggered", cancellationToken: stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error while sending notifications.");
                }
            }

            _logger.LogInformation("NotificationScheduler stopping.");
        }


        private static DateTimeOffset GetNextSchedule(DateTimeOffset now)
        {
            var today = now.Date;
            foreach (var timeOfDay in ScheduleTimes.OrderBy(t => t))
            {
                var candidate = today + timeOfDay;
                if (candidate > now)
                    return candidate;
            }

            var tomorrow = today.AddDays(1);
            return tomorrow + ScheduleTimes.OrderBy(t => t).First();
        }
    }
}

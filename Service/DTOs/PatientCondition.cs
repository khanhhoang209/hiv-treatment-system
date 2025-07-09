namespace Service.DTOs;

public class PatientCondition
{
    public int Age { get; set; }
    public bool AcuteHIVInfection { get; set; }
    public bool ChronicHIVInfection { get; set; }
    public bool HasAIDS { get; set; }
    public bool IsPregnant { get; set; }
    public bool HasHepatitisB { get; set; }
    public bool HasTB { get; set; }
}
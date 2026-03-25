namespace HazardAnalysis.Models;

public class AnalysisItem
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N")[..8];
    public string Text { get; set; } = "";
}

public class TaskStep : AnalysisItem
{
    public int Order { get; set; }
    public List<string> LinkedOutcomeIds { get; set; } = new();
}

public class Hazard : AnalysisItem
{
    public List<string> LinkedStepIds { get; set; } = new();
    public RiskLevel Likelihood { get; set; } = RiskLevel.Medium;
    public RiskLevel Severity { get; set; } = RiskLevel.Medium;
}

public class Mitigation : AnalysisItem
{
    public List<string> LinkedHazardIds { get; set; } = new();
    public MitigationType Type { get; set; } = MitigationType.Administrative;
}

public enum RiskLevel { Low, Medium, High, Critical }

public enum MitigationType
{
    Elimination,
    Substitution,
    Engineering,
    Administrative,
    PPE
}

public class PreTaskAnalysis
{
    public string Title { get; set; } = "";
    public string CreatedBy { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public List<AnalysisItem> Outcomes { get; set; } = new();
    public List<TaskStep> Steps { get; set; } = new();
    public List<Hazard> Hazards { get; set; } = new();
    public List<Mitigation> Mitigations { get; set; } = new();
}

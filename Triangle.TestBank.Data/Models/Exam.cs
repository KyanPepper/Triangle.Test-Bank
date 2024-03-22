namespace Triangle.TestBank.Data.Models;

public class Exam
{
    public int ExamId { get; set; }

    public required string Name { get; set; }

    public required Subjects Subject { get; set; }

    public required Terms Term { get; set; }

    public required  String PdfPath { get; set; }

    
}

public enum Subjects    
{
    CPTS,
    MATH,
    ENGR,
    PHYS,
    CHEM,
    BIO,
    EE,
    ME,
    CE,
    MSE,
    STAT,
    CSTM
}

public enum Terms
{
    Fall2021,
    Spring2021,
    Fall2022,
    Spring2022,
    Fall2023,
    Spring2023,
    Fall2024,
    Spring2024,
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Student
{
    [Key]
    public int StudentKey { get; set; }

    [Required]
    public string StudentName { get; set; } = string.Empty;

    [Required]
    public int SubjectKey { get; set; }

    [Required]
    public int Grade { get; set; }

    [NotMapped]
    public string Remarks => Grade >= 75 ? "PASS" : "FAIL";
}
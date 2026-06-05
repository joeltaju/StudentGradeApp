using Microsoft.AspNetCore.Mvc;

public class ReportController : Controller
{
    private readonly AppDbContext _context;

    public ReportController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index(string search, string remarks)
    {
        var query =
            from s in _context.Students
            join sub in _context.Subjects
            on s.SubjectKey equals sub.SubjectKey
            select new StudentResultVM
            {
                StudentName = s.StudentName,
                SubjectName = sub.SubjectName,
                Grade = s.Grade,
                Remarks = s.Grade >= 75 ? "PASS" : "FAIL"
            };

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(x =>
                x.StudentName.Contains(search));
        }

        if (!string.IsNullOrEmpty(remarks))
        {
            query = query.Where(x =>
                x.Remarks == remarks);
        }

        return View(query.ToList());
    }
}
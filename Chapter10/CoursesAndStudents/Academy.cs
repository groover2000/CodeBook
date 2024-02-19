using Microsoft.EntityFrameworkCore;

namespace CoursesAndStudents;


public class Academy : DbContext
{
    public DbSet<Student>? Students { get; set; }
    public DbSet<Course>? Courses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Academy;Integrated Security=true;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Student alice = new()
        {
            StudentId = 1,
            FirstName = "Alice",
            LastName = "Jones"
        };
        Student bob = new()
        {
            StudentId = 2,
            FirstName = "Bob",
            LastName = "Smith"
        };
        Student cecilia = new()
        {
            StudentId = 3,
            FirstName = "Cecilia",
            LastName = "Ramirez"
        };

        Course csharp = new()
        {
            CourseID = 1,
            Title = "About C#"
        };
        Course webdev = new()
        {
            CourseID = 2,
            Title = "Web Development",
        };
        Course python = new()
        {
            CourseID = 3,
            Title = "Python for Beginners",
        };
        modelBuilder.Entity<Student>()
        .HasData(alice, bob, cecilia);
        modelBuilder.Entity<Course>()
        .HasData(csharp, webdev, python);
        modelBuilder.Entity<Course>()
        .HasMany(c => c.Students)
        .WithMany(s => s.Courses)
        .UsingEntity(e => e.HasData(
        // все студенты записались на курс C#
        new { CoursesCourseID = 1, StudentsStudentId = 1 },
        new { CoursesCourseID = 1, StudentsStudentId = 2 },
        new { CoursesCourseID = 1, StudentsStudentId = 3 },
        // только Боб записался на Web Dev
        new { CoursesCourseID = 2, StudentsStudentId = 2 },
        // только Сесилия записалась на Python
        new { CoursesCourseID = 3, StudentsStudentId = 3 }
        ));
    }
}
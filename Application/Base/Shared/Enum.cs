namespace Application.Base.Shared
{
    public enum StatusResult
    {
        Falid,
        Success,
        Exist,
        NotExists,
        ApplicationException,
        ValidationException,
        Forbidden,
        NotActive
    }
    public enum Gender
    {
        Male = 1,
        Female = 2
    }
    public enum LanguageType
    {
        Ar = 1,
        En = 2
    }

    public enum enumPagesID
    {
        JobClasses,
        Jobs,
        Grades,
        Qualifications,
        QualificationTypes,
        QualificationEntities
    }
}

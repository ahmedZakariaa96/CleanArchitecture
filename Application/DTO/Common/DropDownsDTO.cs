namespace Application.DTO
{
    public class DropDownsDTO
    {
        public virtual IReadOnlyCollection<LookUpsDTO>? JobClasses { get; set; }
        public virtual IReadOnlyCollection<LookUpsDTO>? Jobs { get; set; }
        public virtual IReadOnlyCollection<LookUpsDTO>? Grades { get; set; }
        public virtual IReadOnlyCollection<LookUpsDTO>? Qualifications { get; set; }
        public virtual IReadOnlyCollection<LookUpsDTO>? QualificationTypes { get; set; }
        public virtual IReadOnlyCollection<LookUpsDTO>? QualificationEntities { get; set; }





    }
}

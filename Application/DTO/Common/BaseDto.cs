namespace Application.DTO.Common
{
    public class BaseDto
    {
        public DateTime InsertDate { get; set; }
        public decimal InsertBy { get; set; }
        public decimal? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime DeletedDate { get; set; }
        public decimal DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}

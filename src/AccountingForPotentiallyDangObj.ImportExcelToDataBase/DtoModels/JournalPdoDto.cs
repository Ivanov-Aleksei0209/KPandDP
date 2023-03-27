namespace AccountingForPotentiallyDangObj.ImportExcelToDataBase.DtoModels
{
    public class JournalPdoDto
    {
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public int JournalNumber { get; set; }
    }
}

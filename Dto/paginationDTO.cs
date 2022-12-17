namespace MoviesApi.Dto
{
    public class paginationDTO
    {
        public int page { get; set; } = 1;
        private int recordPerPage = 10;
        private readonly int totalRecordsPerPage = 50;

        public int RecordPerPage {
            get
            {
                return recordPerPage;

            }
            set
            {
                recordPerPage = (value > totalRecordsPerPage)? totalRecordsPerPage: value; 
            }
}

    }
}

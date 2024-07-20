namespace CoreWebApp_2_4.Model
{
    public class PaginationModel
    {
        public int TotalPage { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        public PaginationModel()
        {
            
        }

        public PaginationModel(int CurrentPageNo,int TotalItems,int PageSize = 10)
        {
            this.CurrentPage = CurrentPageNo;

            if(PageSize < 5)
                PageSize = 5;

            this.PageSize = PageSize;

            TotalPage = (int)Math.Ceiling((decimal)TotalItems / PageSize);//9

            if (CurrentPage > TotalPage)
                CurrentPage = 1;

            StartPage = CurrentPage - 5;//-4
            EndPage = CurrentPage + 4;//5

            if (StartPage <= 0)
            {
                EndPage = EndPage - (StartPage - 1);//10
                StartPage = 1;
            }

            if (EndPage > TotalPage)
            {
                EndPage = TotalPage;

                if (((EndPage - StartPage) < 9) && TotalPage >= 10)
                {
                    StartPage = EndPage - 9;
                }
            }
        }
    }
}

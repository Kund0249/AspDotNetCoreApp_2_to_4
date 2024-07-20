namespace CoreWebApp_2_4.Model
{
    public class Pager
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }

        public PaginationModel Pagination { get; set; }

        public Pager(string controllerName,string actionName,PaginationModel model)
        {
            ControllerName = controllerName;
            ActionName = actionName;
            Pagination = model;
        }
    }
}

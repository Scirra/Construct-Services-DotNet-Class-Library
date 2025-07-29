using System.Collections.Generic;

namespace ConstructServices.Common;

public class PaginationOptions
{
    internal int RequestedPage { get; private set; }
    internal int? RecordsPerPage { get; private set; }
        
    public PaginationOptions()
    {
        RequestedPage = 1;
    }
    public PaginationOptions(int requestedPage)
    {
        RequestedPage = requestedPage;
    }
    public PaginationOptions(int requestedPage, int recordsPerPage)
    {
        RequestedPage = requestedPage;
        RecordsPerPage = recordsPerPage;
    }
}
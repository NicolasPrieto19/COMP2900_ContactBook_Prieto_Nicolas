namespace ContactBook;

public class ContactComparer : IComparer<Contact>
{
    public enum SortType
    {
        fname,
        lname,
        phone,
        Email
    };

    private SortType sortType;
    public ContactComparer(SortType sortType)
    {
        SetSortType(sortType);
    }
    public SortType GetSortType()
    {
        return sortType;
    }
    public void SetSortType(SortType sortType)
    {
        this.sortType = sortType;
    }
    public int Compare(Contact? x, Contact? y)
    {
        int r = 0;
        switch (sortType)
        {
            case SortType.lname: return
                (r = string.Compare(x?.GetLname(), y?.GetLname())) != 0 ? r :
                (r = string.Compare(x?.GetFname(), y?.GetFname())) != 0 ? r :
                (r = string.Compare(x?.GetPhone(), y?.GetPhone())) != 0 ? r :
                string.Compare(x?.GetEmail(), y?.GetEmail());
            case SortType.phone: return
                (r = string.Compare(x?.GetPhone(), y?.GetPhone())) != 0 ? r :
                (r = string.Compare(x?.GetLname(), y?.GetLname())) != 0 ? r :
                (r = string.Compare(x?.GetFname(), y?.GetFname())) != 0 ? r :
                string.Compare(x?.GetEmail(), y?.GetEmail());
            case SortType.Email: return
                (r = string.Compare(x?.GetEmail(), y?.GetEmail())) != 0 ? r :
                (r = string.Compare(x?.GetLname(), y?.GetLname())) != 0 ? r :
                (r = string.Compare(x?.GetFname(), y?.GetFname())) != 0 ? r :
                string.Compare(x?.GetPhone(), y?.GetPhone());
            case SortType.fname:
            default:return
                (r = string.Compare(x?.GetFname(), y?.GetFname())) != 0 ? r :
                (r = string.Compare(x?.GetLname(), y?.GetLname())) != 0 ? r :
                (r = string.Compare(x?.GetPhone(), y?.GetPhone())) != 0 ? r :
                string.Compare(x?.GetEmail(), y?.GetEmail());
        }    
    }       
}
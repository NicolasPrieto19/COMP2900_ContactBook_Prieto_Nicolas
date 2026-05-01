using System.Drawing;

namespace ContactBook;

public class ContactBook
{
    public const string YES = "Y";
    public const string NO = "N";
    public readonly string[] YES_NO = new string[] { YES, NO };
    public const string NEXT_PAGE = "+";
    public const string PREV_PAGE = "-";
    public const string GOTO_PAGE = "G";
    public const string PAGE_SIZE = "S";
    public const string CREATE_CONTACT = "C";
    public const string REVIEW_CONTACT = "R";
    public const string UPDATE_CONTACT = "U";
    public const string DELETE_CONTACT = "D";
    public const string FIND_CONTACTS = "F";
    public const string ORDER_CONTACTS = "O";
    public const string DEDUPLICATE_CONTACTS = "M"  ;
    public const string EXIT = "X";

    public readonly string[] COMMANDS = new string[]
    {
        NEXT_PAGE, PREV_PAGE, GOTO_PAGE, PAGE_SIZE, CREATE_CONTACT, REVIEW_CONTACT,
        UPDATE_CONTACT, DELETE_CONTACT, FIND_CONTACTS, ORDER_CONTACTS, DEDUPLICATE_CONTACTS, EXIT
    };
    
    private List<Contact> allContacts;

    private int page;
    private int size;
    private bool isExit = false;

    //Todos los contacs se guardan en memoria, no hay persistencia. 
    // Se pueden pasar contactos al constructor para iniciar con algunos contactos ya creados.
    public ContactBook(List<Contact> contacts = null!)
    {
      allContacts = (contacts == null) ?  new List<Contact>() : contacts;
        page = 1;
        size = 10;
    }

    public void Start()
    {
        ShowWelcomeScreen();

        string input;
        do
        {
            do
            {
                ShowContacts();
                ShowInputOptions();
                input = GetInput();
            }
            while(!IsValidInput(input));

            ProcessInput(input);
        }
        while(!ConfirmExit());

        ShowExitScreen();
    }

    private void ShowWelcomeScreen()
    {
        Console.WriteLine("Welcome to the Nicola's Contact Book!");
        PressEnterToContinue();
    }
   private void ShowContacts()
    {
        ShowContacts(allContacts, page, size);
    }
    private void ShowContacts(List<Contact>? contacts, int page, int size)
    {
        Console.Clear();
        if(contacts?.Count <= 0)
        {
            Console.WriteLine("No contacts found.");
        }
        else
        {

            int indexCol = Math.Max("#".Length, contacts.Count.ToString().Length);
            int fnameCol = Math.Max("First Name".Length, contacts.Max(c => c.GetFname()?.Length ?? 0));
            int lnameCol = Math.Max("Last Name".Length, contacts.Max(c => c.GetLname()?.Length ?? 0));
            int phoneCol = Math.Max("Phone".Length, contacts.Max(c => c.GetPhone()?.Length ?? 0));
            int emailCol = Math.Max("Email".Length, contacts.Max(c => c.GetEmail()?.Length ?? 0));
            Console.WriteLine(""
             + "{0, " + -indexCol + "}  "
             + "{1, " + -fnameCol + "}  "
             + "{2, " + -lnameCol + "}  "
             + "{3, " + -phoneCol + "}  "
             + "{4, " + -emailCol + "}  ",
             "#", "First Name", "Last Name", "Phone", "Email");
            Console.WriteLine(new string('—', (indexCol + 2 + fnameCol + 2 + lnameCol + 2 + phoneCol + 2 + emailCol + 2)));

            int n = contacts.Count;
            int pageCount = PageCount(contacts, size);
            int s = Math.Clamp((page - 1) * size, 0, n);
            int e = Math.Clamp(s + size, 0, n);

            for (int i = s; i < e; i++)
            {
                Contact c = allContacts[i];

                Console.WriteLine(""
                + "{0, " + indexCol + "}  "
                + "{1, " + fnameCol + "}  "
                + "{2, " + lnameCol + "}  "
                + "{3, " + phoneCol + "}  "
                + "{4, " + emailCol + "}  ",
                (i + 1), c.GetFname(), c.GetLname(), c.GetPhone(), c.GetEmail());
            }
            for (int i = 0; i < size - e + s; i++)
            {
            Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine($"Page {page} of {pageCount} ({s + 1} - {e} of {n}) ");
        }
    }

    private void ShowInputOptions()
    {
        string inputOptions = ""
        + $"[{NEXT_PAGE}] Next Page | [{CREATE_CONTACT}] Create Contact | [{DELETE_CONTACT}] Delete Contact | [{DEDUPLICATE_CONTACTS}] Deduplicate Contacts\n"
        + $"[{PREV_PAGE}] Prev Page | [{REVIEW_CONTACT}] Review Contact | [{FIND_CONTACTS }] Find Contacts  | [{PAGE_SIZE           }] Set Page Size\n"
        + $"[{GOTO_PAGE}] Goto Page | [{UPDATE_CONTACT}] Update Contact | [{ORDER_CONTACTS}] Order Contacts | [{EXIT                }] Exit\n"
        + $"\n> ";

        Console.WriteLine();
        Console.Write(inputOptions);

    }

    private string GetInput()
    {
        return Console.ReadLine()!.ToUpper();
    }

    private bool IsValidInput(string input)
    {
        if(!COMMANDS.Contains(input))
        {
            Console.WriteLine($"Invalid input. Please try again.");
            PressEnterToContinue();
            return false;
        }
        else
        {
            return true;
        }
    }

    private void ProcessInput(string input)
    {
        switch(input)
        {
            case NEXT_PAGE:
                Console.Write("> Next Page");
                NextPage();
                break;
            case PREV_PAGE:
                Console.Write("> Prev Page");
                PrevPage();
                break;
            case GOTO_PAGE:
                Console.Write("> Goto Page");
                break;
            case PAGE_SIZE:
                Console.Write("> Set Page Size");
                break;
            case CREATE_CONTACT:
                Console.Write("> Create Contact");
                break;
            case REVIEW_CONTACT:
                Console.Write("> Review Contact");
                break;
            case UPDATE_CONTACT:
                Console.Write("> Update Contact");
                break;
            case DELETE_CONTACT:
                Console.Write("> Delete Contact");
                break;
            case FIND_CONTACTS:
                Console.Write("> Find Contacts");
                break;
            case ORDER_CONTACTS:
                Console.Write("> Order Contacts");
                break;
            case DEDUPLICATE_CONTACTS:
                Console.Write("> Deduplicate Contacts");
                break;
            case EXIT:
                Console.Write("> Exit");
                Exit();
                break;
        }
    }
    private void NextPage()
    {
        NextPage(allContacts,ref page, size);
    }

    private void NextPage(List<Contact> contacts,ref int page, int size)
    {
        page = Math.Clamp(page + 1, 1, PageCount(contacts, size));
    }
    private void PrevPage()
    {
        PrevPage(allContacts,ref page, size);
    }
    private void PrevPage(List<Contact> contacts,ref int page, int size)
    {
        page = Math.Clamp(page - 1, 1, PageCount(contacts, size));
    }

    private bool ConfirmExit()
    {
        return (isExit) ? Confirm("\nDo you want to exit? ", NO) : false;
    }

    private void ShowExitScreen()
    {
        Console.Clear();
        Console.WriteLine("Thank you for using Nicola's Contact Book. Goodbye!");

    }

    private void PressEnterToContinue()
    {
        Console.WriteLine("Press ENTER to continue...");
        while(Console.ReadKey(true).Key != ConsoleKey.Enter);
    }

    private string GetOptions(string prompt, string[] validOptions, string defaultOption)
    {
        string options = string.Join("/", validOptions);

        Console.Write(prompt + $"[{options}] ({defaultOption}) ");
        string option = Console.ReadLine()!.ToUpper();

        if (string.IsNullOrWhiteSpace(option))
        {
            option = defaultOption;
        }
        while (!validOptions.Contains(option))
        {
            Console.WriteLine($"Invalid option. Please try again.");
            Console.Write(prompt + $"[{options}] ({defaultOption}) ");
            option = Console.ReadLine()!.ToUpper();

            if (string.IsNullOrWhiteSpace(option))
            {
                option = defaultOption;
            }
        }
         return option;
    }

    private void Exit()
    {
        isExit = true;
    }

    private bool Confirm(string prompt, string defaultOption)
    {
       return GetOptions(prompt, YES_NO, defaultOption) == YES;
    }
        private static int PageCount(List<Contact> contacts, int size)
    {
        return (int)Math.Max(1, Math.Ceiling(contacts.Count / (double)size));
    }
}
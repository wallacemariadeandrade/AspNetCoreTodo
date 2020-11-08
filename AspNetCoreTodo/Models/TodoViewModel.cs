namespace AspNetCoreTodo.Models
{
    /*
    In this case, the TodoItem model represents a single item 
    in thedatabase, but the view might need to display two, ten, or 
    a hundred to-do items (depending on how badly the user is procrastinating).
    Because of this, the view model should be a separate class that 
    holds anarray of TodoItems
    */
    public class TodoViewModel
    {
        public TodoItem[] Items { get; set; }
    }
}
# BookInfo-WebApp-Core3

# Changes on the validation branch

## Changes to the models

- Author

  ```C#
  [Required]
  [StringLength(100, MinimumLength = 2)]
  public string Name { get; set; }
  
  [DataType(DataType.Date)]  // causes default validation and sets the HTML5 data type
  [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]  // just format, no validation
  public DateTime Birthday { get; set; }
  
  ```

  

- Book:

  ```C#
  [Required]
  [StringLength(100, MinimumLength = 2)]  
  public string Title { get; set; }
  
  [Required]
  [DataType(DataType.Date)]  // causes validation and sets the HTML5 data type
  [DisplayFormat(DataFormatString = "{0:yyyy}")]  // just formatting, doesn't validate
  public DateTime PubDate { get; set; }
  
   
  ```

- Comment: no changes

- Review: no changes

- User: no changes



## Changes to the controller methods

- BookController, AddBook now has a check for model state and has Book as a parameter

  ```C#
          [HttpPost]
          public RedirectToActionResult AddBook(Book book)
          {
              if (ModelState.IsValid)
              {
                  repo.AddBook(book);
              }
              return RedirectToAction("Index");
          }
  ```

- AuthorController, Edit has changes similar to those above, but still uses form fields as parameters.



## Changes to the views

- Book/AddBook.cshtml: Added validation code like that shown  below.

  ```html
  <div asp-validation-summary="ModelOnly" style="background-color: red"></div>
  <label asp-for="Title">Title</label>
  <input asp-for="Title" />
  <span asp-validation-for="Title"></span><br />
  <!-- additional code omitted, it repeats the same pattern -->
  ```

  Just the `asp-validation-summary` and `asp-validation-for` were added on this branch.

- Author/AuthorEntry: Similar changes to those above.



## TODO

1. Use view models for with the AddBook and AuthorEntry views so that I can use a string for dates instead of DateTime which will allow me to customize the date entry format.
2. Create a shared layout for views with validation so that I don't have to keep putting the script elements for validation JS in each view.
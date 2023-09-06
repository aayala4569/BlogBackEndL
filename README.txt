//Goal

//Create a backend for a blog site
//Create a front end for our blog site
//Deploy to Azure
//Learn about Devopd and Scrum (Tools used to get projects out)

Create an API for our Blog. This API must handle all CRUD functions.(Create, Read, Update and Delete)

//In this APP the user should be able create an account and login
  Blog page to view all the published items
  Dashboard(The user profile page to allow them to edit, delete and add blog items)

  We will talk about folder stucture
Controller// will be a folder
    .UserController will handel all our user interactions
    .Login- endpoints
    .Add a user- endpoints
    .Update a user
    .Delete a user
BlogController//file
    .Add Blog items- endpoint C
    .GetAllBlogItems- endpoint R 
    .GetBlogItemsByCategory
    .GetBlogItemsByTags
    .GetBlogItemsByDate
    .UpdateBlogItems- endpoint U
    .DeleteBlogItems- endpoint D
Model//folder
    .UserModel
        int for ID
        string Username
        string Salt
        string Hash 256 characters
    .BlogItemModel   
        int ID
        int UserID
        string PublisherName
        string Title
        string Image
        string Description
        string Date
        string Category
        bool IsPublished
        bool IsDeleted

-----------------------Items that will be saved to our database DB are above----------------------

    LoginModelDTO
        string Username
        string password
    CreateAccountModelDTO
        int ID = 0
        string Username
        string password
    PasswordModelDTO
        string Salt
        string Hash


Services//folder    
    Context//folder

        UserService//file
            GetUserByUsername
            Login
            Add User
            Delete User

        BlogItemService//file
            .Add Blog items- function C
            .GetAllBlogItems- function R 
            .GetBlogItemsByCategory
            .GetBlogItemsByTags
            .GetBlogItemsByDate
            .UpdateBlogItems- function U
            .DeleteBlogItems- function D
            .GetUserByID- function
            
        PasswordService//file
            .Hash Password
            .Very Hash Password

            "Server Admin log in: academyblogAdmin Password: AcademyBlogPassword"
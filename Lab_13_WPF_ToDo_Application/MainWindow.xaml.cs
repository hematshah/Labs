using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab_13_WPF_ToDo_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> items = new List<string>();
        List<Task> tasks = new List<Task>();
        Task task = new Task();
        List<Category> categories = new List<Category>();
        List<TaskwithCategory> taskwithCategories = new List<TaskwithCategory>(); 

        
        public MainWindow()
        {
            InitializeComponent();
            // IntialiseListBoxOfStrings();
            Initialise();

        }

        #region Old code
        //void IntialiseListBoxOfStrings() 
        //{
        //    //items.Add("he this is a list box");
        //    //items.Add("he this is a list box");
        //    //items.Add("he this is a list box");
        //    ListBoxTasks.ItemsSource = items;
        //    items.Add("he this is a new list box");
        //    using (var db = new TaskDBEntities())
        //    {
        //        taskItems = db.Tasks.ToList();
        //    }

        //    // get discription and add to list
        //    foreach (var item in taskItems)
        //    {
        //        items.Add($"{item.TaskID, -5}{item.Description, -15}{item.Done, -20}{item.DateCompleted, -30}{item.UserID, -10}{item.CategoryID}");

        //    }
        //}
        #endregion

        void Initialise() 
        {
            using (var db = new TaskDBEntities()) 
            {
                tasks = db.Tasks.ToList(); // same as below
                categories = db.Categories.ToList(); // retrieves the categories from table and feeds it to a list called categories
            }
            ListBoxTasks.ItemsSource = tasks;
            ListBoxTasks.DisplayMemberPath = "Description";
            ComboBoxCategory.ItemsSource = categories;
            ComboBoxCategory.DisplayMemberPath = "CategoryName";


            // Inner Join
            using (var db = new TaskDBEntities())
            {
                // task but it has a categoryID. inner join => CATEGORYID
                var taskList =

                from task in db.Tasks
                join Category in db.Categories on
                task.CategoryID equals Category.CategoryId



                #region test join
                //select new
                //{
                //   taskID = task.TaskID,
                //   description = task.Description,
                //   category = Category.CategoryName
                //};

                //foreach (var task in taskList.ToList())
                //{
                //    //System.Diagnostics.Trace.WriteLine($"{task.TaskId, -10}{task.TaskDescriptions, -20}{task.CategoryNames}");

                //}
                #endregion

                select new TaskwithCategory()
                {
                    TaskId = task.TaskID, 
                    TaskDescriptions = task.Description,
                    CategoryNames = Category.CategoryName
                };

                // add  to list
                taskwithCategories = taskList.ToList();
                
                MyDataGrid.ItemsSource = categories;
                ListviewCategory.ItemsSource =  taskwithCategories;

            }
        }

        private void ListBoxTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // print out the details of the selected items
            // instance = (convert to Task) the item selected in listBox by user
            // DO NOT USE RESERVE WORDS LIKE Task in this case the c# is refering task to this namespace
            task = (Task)ListBoxTasks.SelectedItem;
            if (task !=null)
            {
                TextBoxId.Text = task.TaskID.ToString();
                TextBoxDescription.Text = task.Description;
                TextBoxCategoryId.Text = task.CategoryID.ToString();
                ButtonEdit.IsEnabled = true;
                ButtonAdd.IsEnabled = true;
                ButtonDelete.IsEnabled = true;
                if (task.CategoryID != null)
                {
                    ComboBoxCategory.SelectedIndex = (int)task.CategoryID -1;
                }
                else 
                {
                    ComboBoxCategory.SelectedItem = null;
                }
                
            }
            
        }

        private void ListBoxTask_DoubleClick(object sender, MouseButtonEventArgs e ) 
        {
            // get object
            task = (Task)ListBoxTasks.SelectedItem;
            if (task != null)
            {
                TextBoxId.Text = task.TaskID.ToString();
                TextBoxDescription.Text = task.Description;
                TextBoxCategoryId.Text = task.CategoryID.ToString();
                ButtonEdit.IsEnabled = true;
                ButtonAdd.IsEnabled = true;
                ButtonDelete.IsEnabled = true;
                if (task.CategoryID != null)
                {
                    ComboBoxCategory.SelectedIndex = (int)task.CategoryID - 1;
                }
                else
                {
                    ComboBoxCategory.SelectedItem = null;
                }

                TextBoxDescription.IsReadOnly = false;
                TextBoxCategoryId.IsReadOnly = false;
                ButtonEdit.Content = "Save";

                TextBoxDescription.Background = Brushes.White;
                TextBoxCategoryId.Background = Brushes.White;

            }
        }


        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonEdit.Content.ToString() == "Edit")  // one = is to assign but two == is to validate
            {
                TextBoxDescription.IsReadOnly = false;
                TextBoxCategoryId.IsReadOnly = false;
                ButtonEdit.Content = "Save";
                
                TextBoxDescription.Background = Brushes.White;
                TextBoxCategoryId.Background = Brushes.White;

            }
            else 
            {
                using (var db = new TaskDBEntities()) 
                {
                    var taskToEdit = db.Tasks.Find(task.TaskID);
                    // update description & categoryid
                    taskToEdit.Description = TextBoxDescription.Text;
                    // convering category id to integer using tryparse 
                    // because the textbox containing text is of type integer regardless of the type categoryid being of a type int
                    int.TryParse(TextBoxCategoryId.Text, out int categoryid);
                    taskToEdit.CategoryID = categoryid;
                    if (task.CategoryID != null)
                    {
                        ComboBoxCategory.SelectedIndex = (int)taskToEdit.CategoryID - 1;
                    }
                    else
                    {
                        ComboBoxCategory.SelectedItem = null;
                    }

                    // save the changes of the box
                    db.SaveChanges();
                    // update list box
                    ListBoxTasks.ItemsSource = null; // reset list box
                    tasks = db.Tasks.ToList();
                    ListBoxTasks.ItemsSource = tasks;

                }
                ButtonEdit.Content = "Edit";
                TextBoxDescription.IsReadOnly = true;
                TextBoxCategoryId.IsReadOnly = true;
                ButtonEdit.IsEnabled = false;
                var brush = new BrushConverter();
                
                TextBoxDescription.Background = (Brush)brush.ConvertFrom("BlanchedAlmond");
                TextBoxCategoryId.Background = (Brush)brush.ConvertFrom("BlanchedAlmond");


            }

        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e) 
        {
            if (ButtonAdd.Content.ToString() == "Add")
            {
                ButtonAdd.Content = "Confirm";
                // set boxes to editable
                TextBoxDescription.Background = Brushes.White;
                TextBoxCategoryId.Background = Brushes.White;
                TextBoxCategoryId.IsReadOnly = false;
                TextBoxDescription.IsReadOnly = false;
                // clear out boxes
                TextBoxId.Text = "";
                TextBoxDescription.Text = "";
                TextBoxCategoryId.Text = "";
            }
            else 
            {
                ButtonAdd.Content = "Add";
                // set boxes back to read only
                TextBoxDescription.IsReadOnly = true;
                TextBoxCategoryId.IsReadOnly = true;
                var brush = new BrushConverter();
                TextBoxDescription.Background = (Brush)brush.ConvertFrom("BlanchedAlmond");
                TextBoxCategoryId.Background = (Brush)brush.ConvertFrom("BlanchedAlmond");
                // add record to database
                int.TryParse(TextBoxCategoryId.Text, out int categoriesId);
               
                var taskToAdd = new Task()
                {
                    Description = TextBoxDescription.Text,
                    CategoryID = categoriesId
                };
                
                using (var db = new TaskDBEntities()) 
                {
                    db.Tasks.Add(taskToAdd);
                    //if (taskToAdd.CategoryID.GetType() == typeof(string)) 
                    //{
                    //    var newCategory = new Category
                    //    {
                    //        CategoryName = TextBoxCategoryId.Text
                    //    };
                    //    db.Categories.Add(newCategory);


                    //}
                    db.SaveChanges();
                    ListBoxTasks.ItemsSource = null; // reset list box
                    tasks = db.Tasks.ToList();
                    ListBoxTasks.ItemsSource = tasks;

                }
            }

        }


        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonDelete.Content.ToString() == "Delete")
            {
                ButtonDelete.Content = "Are You Sure?";  // set boxes to Delete
                var brush = new BrushConverter();
                TextBoxId.Background = (Brush)brush.ConvertFrom("#e03636");
                TextBoxDescription.Background = (Brush)brush.ConvertFrom("#e03636");
                TextBoxCategoryId.Background = (Brush)brush.ConvertFrom("#e03636"); 

            }
            else
            {
                
               

                using (var db = new TaskDBEntities())
                {
                    var deleteTask = db.Tasks.Find(task.TaskID);
                    db.Tasks.Remove(deleteTask);
                    db.SaveChanges();
                    ListBoxTasks.ItemsSource = null; // reset list box
                    tasks = db.Tasks.ToList();
                    ListBoxTasks.ItemsSource = tasks;


                };

                ButtonDelete.Content = "Delete";
                ButtonDelete.IsEnabled = false;
                TextBoxDescription.IsReadOnly = true;
                TextBoxCategoryId.IsReadOnly = true;
                var brush = new BrushConverter();
                TextBoxId.Background = (Brush)brush.ConvertFrom("BlanchedAlmond");
                TextBoxDescription.Background = (Brush)brush.ConvertFrom("BlanchedAlmond");
                TextBoxCategoryId.Background = (Brush)brush.ConvertFrom("BlanchedAlmond");

            }

        }

      
    }

    public class TaskwithCategory 
    {
        // 3 fields

        public int TaskId { get; set; }
        public string TaskDescriptions { get; set; }
        public string CategoryNames { get; set; }
    }
}

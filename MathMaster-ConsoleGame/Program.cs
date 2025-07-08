using System.ComponentModel.Design;

string name;
DateTime date = DateTime.UtcNow;
List<string> games = new();

name = Helpers.GetName();

var Menu = new Menu();
Menu.ShowMenu(name, date);






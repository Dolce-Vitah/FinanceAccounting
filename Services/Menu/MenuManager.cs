using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denisenko_FinanceAccounting.Services.Menu
{
    public class MenuManager
    {
        private readonly ServiceProvider serviceProvider;
        private readonly Stack<IMenu> menuStack = new Stack<IMenu>();

        public MenuManager(ServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Start()
        {
            PushMenu(new MainMenu());
        }

        public void PushMenu(IMenu menu)
        {
            menuStack.Push(menu);
            menu.Show(this);
        }

        public void PopMenu()
        {
            if (menuStack.Count > 1)
            {
                menuStack.Pop();
                menuStack.Peek().Show(this);
            }
            else
            {
                Console.WriteLine("Exiting program...");
                Environment.Exit(0);
            }
        }

        public void ClearStack()
        {
            menuStack.Clear();
        }

        public T GetService<T>() => serviceProvider.GetRequiredService<T>();
    }
}

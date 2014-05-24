using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Amnesia.Clases;

namespace Amnesia.Core
{
    public class DBLayer
    {
        string conect = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "pendingTasks.accdb";

        public DataView getAllRows()
        {
            try
            {
                pendingTaskDataSet dataset = new pendingTaskDataSet();

                pendingTaskDataSetTableAdapters.tasksTableAdapter adapter = new pendingTaskDataSetTableAdapters.tasksTableAdapter();

                adapter.Fill(dataset.tasks);

                if (dataset.tasks.Rows.Count.Equals(0))
                {
                    Registro.id = 1;
                }
                else
                {
                    Registro.id = dataset.tasks.Last().Id;
                }

                return dataset.tasks.DefaultView;
            }
            catch (Exception ex)
            {

                return new DataView();
            }
        }
    }
}

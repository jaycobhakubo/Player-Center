using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics; 


namespace GTI.Modules.PlayerCenter.Data
{
    public class MyListBox : ListBox
    {
        private StringBuilder selectionCache = new StringBuilder();
        public static int y; 

        protected override void OnEnter(EventArgs e)
        {
            //Reset selection cache when control receives focus
            selectionCache.Length = 0;
            base.OnEnter(e);
        }

        protected override void OnClick(EventArgs e)
        {
            selectionCache.Length = 0;
            base.OnClick(e);
        }


        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0102)
            {
                char key = (char)m.WParam;
                if (key == 27)//escape
                {
                    //reset cache if escape pressed
                    selectionCache.Length = 0;
                }
                else if (key == 8)//backspace
                {
                    //allow backspace to delete from cache
                    if (selectionCache.Length > 0)
                    {
                        selectionCache.Length--;
                        SelectFirstItemMatching(selectionCache.ToString());
                    }
                }
                else if (Char.IsLetterOrDigit(key))
                {
                    selectionCache.Append(Char.ToLower(key));
                    SelectFirstItemMatching(selectionCache.ToString());
                }
                //Do not call base.WndProc as we want to eat the message 
                //so that the control doest not respond to it
                return;
            }

            base.WndProc(ref m);
        }

        private void SelectFirstItemMatching(string selectionText)
        {
            int x = -1;
            for (int index = 0; index < Items.Count; index++)
            {
                string itemText = Items[index].ToString().ToLower();
                if (itemText.StartsWith(selectionText))
                {
                    if (index != SelectedIndex)
                    {
                        SelectedIndex = index;
                        x = index ;
                        y = x;
                        break;
                    }
                }
            }
        }


    }



}
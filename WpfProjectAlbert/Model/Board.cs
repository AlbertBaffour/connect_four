using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfProjectAlbert.Model
{
    class Board : ObservableCollection<Zet>
    {
        //variabelen definieren
        public List<int> RowCount = new List<int> {0,0,0,0,0,0,0,0};
        private int total_count = 0;
        private int[,] game;
        private bool end=false;
        public Board(Schijf schijf, List<Schijf> schijfjes,int RowCol)
        {
            CreateBoard(schijf, schijfjes,RowCol);
            PickPlayer1();
        }
      
        public void CreateBoard(Schijf schijf, List<Schijf> schijfjes,int RowCol)
        {
            end = false;
            game = InitIntArray(RowCol);
            int i, j,k=0;
            for (i = 0; i < RowCol; i++)
            {
                for (j = 0; j <RowCol; j++)
                {
                    this.Add(new Zet(k, -1, -1, i, j, schijf.Id, schijf.FillColor));
                    
                    k++;
                }
            }
          
            this.Add(new Zet(-10, -1, -1, 0, 8, 1, schijfjes[0].FillColor));
            this.Add(new Zet(-20, -1, -1, 7, 8, 1, schijfjes[0].FillColor));
        }
        public bool confirmation= false;

        public void PickPlayer1()
        {
           
            this.Add(new Zet(-10, -1, -1, 0, 8, 3, "Red"));
            this.Add(new Zet(-20, -1, -1, 7, 8, 2, "LightGoldenrodYellow"));
            
            
        }
        public void PickPlayer2()
        {
            this.Add(new Zet(-10, -1, -1, 0, 8, 3, "PaleVioletRed"));
            this.Add(new Zet(-20, -1, -1, 7, 8, 2, "Yellow"));

        }
        public void End()
        {
            this.Add(new Zet(-10, -1, -1, 0, 8, 3, "Red"));
            this.Add(new Zet(-20, -1, -1, 7, 8, 2, "yellow"));
            end = true;
        }
        public bool confirm()
        {
            //bevestig zet
            return confirmation;
        }
        
        public Zet Move(int id,int speler_id,int spel_id,int s_id,string s_fillColor)
        {
            if (!end)
            {
                var selectie = this.FirstOrDefault(s => s.Id == id);
                int row = 7 - RowCount[selectie.Kolom];
                if (row >= 0)
                {
                    confirmation = true;
                    total_count++;
                    //schijf toevoegen aan row
                    Zet nieuweZet = new Zet(selectie.Id, speler_id, spel_id, selectie.Kolom, row, s_id, s_fillColor);
                    this.Add(nieuweZet);

                    //aantal schijfjes op de row verhogen
                    RowCount[selectie.Kolom]++;
                    game[row, selectie.Kolom] = speler_id;
                    return nieuweZet;
                }

                confirmation = false;
                return new Zet();
            }
            confirmation = false;
            return new Zet();
          
        }
        public bool IsFull()
        {
            if (total_count >= 64)
            {
                return true;
            }
            return false;
        }
        //Check win
        public bool Checkwin(int id, int RowCol, int player_id)
        {
            if (CheckVertically(id, RowCol, player_id)|| CheckHorizontally(id, RowCol, player_id)|| CheckDiagonals(id, RowCol, player_id))
            {
                return true;
            }
            return false;
        }
        ///  vertical check.
        public bool CheckVertically(int id,int RowCol, int player_id)
        {
            var kolom = this.FirstOrDefault(s => s.Id == id).Kolom;
            int row = 8 - RowCount[kolom];
            if (row + 3 >= RowCol) { return false; }

            for (int i = 0; i < 4; i++)
            {
               if (game[row+i,kolom] != player_id) { return false; }
            }

            return true;
        }
        ///  hori check.
        public bool CheckHorizontally(int id,int RowCol, int player_id)
        {
            int checker1 = 0;
            var kolom = this.FirstOrDefault(s => s.Id == id).Kolom;
            int row = 8 - RowCount[kolom];
            for (int i = 0; i < RowCol; i++)
            {
                if (game[row, i] == player_id) {
                    checker1++;
                    if (checker1 == 4) { return true; }
                }else { checker1 = 0; }
            }

                return false;

        }
        //check diagonals
        public bool CheckDiagonals(int id, int RowCol, int player_id)
        {
            int checker = 0;
            var kolom = this.FirstOrDefault(s => s.Id == id).Kolom;
            int row = 8 - RowCount[kolom];

            // top-left to bottom-right 
            for (int i = 0; i < RowCol - 3; i++)
            {
                checker = 0;
                int r, k;
                for (r = i, k = 0; r < RowCol && k < RowCol; r++,k++)
                {
                    if (game[r,k] == player_id)
                    {
                        checker++;
                        if (checker >= 4) return true;
                    }
                    else
                    {
                        checker = 0;
                    }
                }
            }
            // top-right to bottom-left 
            for (int i = 0; i < RowCol - 3; i++)
            {
                checker = 0;
                int r, k;
                for (r = i, k = 7; r < RowCol && k >=0; r++,k--)
                {
                    if (game[r,k] == player_id)
                    {
                        checker++;
                        if (checker >= 4) return true;
                    }
                    else
                    {
                        checker = 0;
                    }
                }
            }
            // top-left to bottom-right 
            for (int i = 1;i < RowCol - 3; i++)
            {
                checker = 0;
                int r, k;
                for (r = 0, k = i; r < RowCol && k < RowCol; r++, k++)
                {
                    if (game[r,k] == player_id)
                    {
                        checker++;
                        if (checker >= 4) return true;
                    }
                    else
                    {
                        checker = 0;
                    }
                }
            }
            // top-right to bottom-left 
            for (int i = 1;i < RowCol - 3; i++)
            {
                checker = 0;
                int r, k;
                for (r = 0, k = 7-i; r < RowCol && k>=0; r++, k--)
                {
                    if (game[r,k] == player_id)
                    {
                        checker++;
                        if (checker >= 4) return true;
                    }
                    else
                    {
                        checker = 0;
                    }
                }
            }
            return false;
        }
        //array definieren
        public int[,] InitIntArray(int RowCol)
        {
            int[,] grid = new int[RowCol, RowCol];
            int n = 0;

            for (int i = 0; i != RowCol; i++)
            {

                for (int j = 0; j != RowCol; j++)
                {
                    grid[i, j] = n;
                }
            }

            return grid;
        }
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Todo List, -Mon Ai , - Runes -Saving/loading -Lving UP -MainMenu                         -Maingame Screen/Content
// known bugs , if dead and on turn list game crash
// note update AI to only target living players

namespace RpgTest
{






    public partial class FormBack : Form
    {
        static Character Char1 = new Character();
        static Character Char2 = new Character();
        static Character Char3 = new Character();
        static Character Char4 = new Character();

        static Character Mon1 = new Character();
        static Character Mon2 = new Character();
        static Character Mon3 = new Character();
        static Character Mon4 = new Character();
        static Character Mon5 = new Character();
        static Character Mon6 = new Character();
        static Character Mon7 = new Character();
        static Character Mon8 = new Character();

        Character Target = null;
        Character CurrentTurn = null;
        int manacost = 0;
        int damage = 99876;
        string DamageType = null;
        string DamageAttribute = null;
        Skill[] SkillList = new Skill[999];
        Rune[] RuneList = new Rune[999];
        Character[] CharacterList = new Character[12];




        //_______________________________________________________________________________________________________________________Main App
        public FormBack()
        {
            InitializeComponent();

            int ScreenX = MainScreen.Width;
            int ScreenY = MainScreen.Height;
            int Xpos = MainScreen.Location.X + panel10.Location.X + MainBack.Location.X;
            int Ypos = MainScreen.Location.Y + panel10.Location.Y + MainBack.Location.Y;

            
            Mon1.InitiateChar();
            Mon2.InitiateChar();
            Char1.InitiateChar();
            Char2.InitiateChar();
            Char3.InitiateChar();
            Char4.InitiateChar();
            Char1.Speed = 11;
            Char2.Speed = 12;
            Mon1.HP = 50;
            Mon1.maxHP = 50;
            Char2.Cname = "My";
            Char3.Cname = "Name";
            Char4.Cname = "Jeff";
            Char1.Cname = "hi";
            Skill CurrentR = new Skill();
            Char1.SkillList[0] = CurrentR;
            Mon1.SkillList[0] = CurrentR;
            Mon2.SkillList[0] = CurrentR;
            Mon1.Speed = 22;
            Char2.SkillList[0] = CurrentR;
            Mon1.Cname = "M1";
            Mon2.Cname = "M2";



            SkillList[0] = CurrentR;




            setup();

        }
        // ____________________________________________________________________________________________-Other
        void MainMenu() { }
        void BattleWon() { }

        void setup()
        {
            Char1HP.Width = (int)Math.Round((Char1.HP / Char1.maxHP) * 140);
            Char1Mana.Width = (int)Math.Round((Char1.Mana / Char1.maxMana) * 140);
            Char1Name.Text = Char1.Cname;
            Char1Class.Text = (Char1.Class + "  Lv: " + Char1.Level);

            Char2HP.Width = (int)Math.Round((Char2.HP / Char2.maxHP) * 140);
            Char2Mana.Width = (int)Math.Round((Char2.Mana / Char2.maxMana) * 140);
            Char2Name.Text = Char2.Cname;
            Char2Level.Text = (Char2.Class + "  Lv: " + Char2.Level);

            Char3Hp.Width = (int)Math.Round((Char3.HP / Char3.maxHP) * 140);
            Char3Mana.Width = (int)Math.Round((Char3.Mana / Char3.maxMana) * 140);
            Char3Name.Text = Char3.Cname;
            Char3Level.Text = (Char3.Class + "  Lv: " + Char3.Level);

            Char4hp.Width = (int)Math.Round((Char4.HP / Char4.maxHP) * 140);
            Char4mana.Width = (int)Math.Round((Char4.Mana / Char4.maxMana) * 140);
            Char4name.Text = Char4.Cname;
            Char4Level.Text = (Char4.Class + "  Lv: " + Char4.Level);
            HideMon();

            CharacterList[0] = Char1;
            CharacterList[1] = Char2;
            CharacterList[2] = Char3;
            CharacterList[3] = Char4;
            CharacterList[4] = Mon1;
            CharacterList[5] = Mon2;
            CharacterList[6] = Mon3;
            CharacterList[7] = Mon4;
            CharacterList[8] = Mon5;
            CharacterList[9] = Mon6;
            CharacterList[10] = Mon7;
            CharacterList[11] = Mon8;





        }



        //______________________________________________________________________________________________Battles

        class Speed {
            public int UserSpeed = -9999;
            public Character Chara; }


        int TurnsRemaining = 0;
        double PlayerTeamHP = Char1.HP + Char2.HP + Char3.HP + Char4.HP;
        double MonsterTeamHp = Mon1.HP + Mon2.HP + Mon3.HP + Mon4.HP + Mon5.HP + Mon6.HP + Mon7.HP + Mon8.HP;
        Speed Fastest = new Speed();
        Speed[] SArray = new Speed[12];

        void CalcTurnOrder()
        {
            for (int I = 0; I < 11; I++)
            {
                if (CharacterList[I].HP > 0)
                {
                    Speed Holder = new Speed();
                    Holder.UserSpeed = CharacterList[I].Speed;
                    Holder.Chara = CharacterList[I];
                    SArray[I] = Holder;
                    TurnsRemaining++;
                }
            }
        }


        void SetFastest()
        {
            for (int I = 0; I < 12; I++)
            {
                if (SArray[I] != null)
                {
                    if (SArray[I].UserSpeed > Fastest.UserSpeed)
                    {
                        Fastest.UserSpeed = SArray[I].UserSpeed;
                        Fastest.Chara = SArray[I].Chara;
                    }
                }
            }

            CurrentTurn = Fastest.Chara;
            Fastest.Chara = null;
            Fastest.UserSpeed = -9999;
            for (int I = 0; I < 12; I++)
            {
                if (SArray[I] != null)
                {
                    if (SArray[I].Chara == CurrentTurn)
                    {
                        SArray[I] = null;
                    }
                }
            }
        }


        void DoTurn() {
            if (CurrentTurn.Cname == Char2.Cname || CurrentTurn.Cname == Char1.Cname || CurrentTurn.Cname == Char3.Cname || CurrentTurn.Cname == Char4.Cname)
            {
                combatMenuOne();
                CombatList.Show();
            }

            else
            {
                CombatList.Hide();
                runAI(CurrentTurn.AIType);
            }
        }

        void Battle(Monlist Input) {
            ShowMons(Input.MonCount);
            CalcTurnOrder();
            SetFastest();
            DoTurn();
        }

        void runAI(string AIType)
        {
            if (AIType == "AttackOnly"){
                
                Random rand = new Random();
                int ranum = rand.Next(4);
                string SelectedSkill = "Blank";

                for (int I = 0; I < CurrentTurn.SkillList.Length; I++)
                {
                    if (CurrentTurn.SkillList[I]!=null) {
                        Console.WriteLine("Here");
                        if (CurrentTurn.SkillList[I].skillType == "Attack") { SelectedSkill = CurrentTurn.SkillList[I].Name; }
                    } }

               
                if (ranum == 1) { Target = Char1; };
                if (ranum == 2) { Target = Char2; };
                if (ranum == 3) { Target = Char3; };
                if (ranum == 4) { Target = Char4; };
                Console.WriteLine(SelectedSkill + Target.Cname+"  |"+CurrentTurn.Cname);
                UseAbility(SelectedSkill);
               
            }
        }
                

        public void DamageCalc()
        {
            if (Target != null && damage != 99876)
            {

                if (DamageAttribute==Target.weakness) { damage = damage * 2; }


                if (DamageType == "Phy") { Target.HP -= (damage/Target.DEF);
                    if (Target.HP<0) { Target.HP = 0; }
                }


                else if (DamageType == "Mag") { Target.HP -= (damage / Target.SDF);
                    if (Target.HP < 0) { Target.HP = 0; };
                }


                CurrentTurn.Mana = CurrentTurn.Mana - manacost;
                Redraw();
                DamageAttribute = null;
                DamageType = null;
                damage = 99876;
                Target = null;
                manacost = 0;
                TurnEnd();
            }
        }



                void TurnEnd()
            {
            PlayerTeamHP = Char1.HP + Char2.HP + Char3.HP + Char4.HP;
            MonsterTeamHp = Mon1.HP + Mon2.HP + Mon3.HP + Mon4.HP + Mon5.HP + Mon6.HP + Mon7.HP + Mon8.HP;
            TurnsRemaining--;
            if (PlayerTeamHP > 0 && MonsterTeamHp > 0)
            {
                if (TurnsRemaining <= 0)
                {
                    CalcTurnOrder();
                    SetFastest();
                    DoTurn();
                    
                }
                else
                {
                    SetFastest();
                    DoTurn();
                }
            }

            else if (PlayerTeamHP <= 0) {
                MainMenu(); 
            }
            else if (MonsterTeamHp <= 0) { 
                HideMon();
                BattleWon();
                }
            
            }


        void combatMenuOne()
        {
            CombatList.Items.Add("What will "+CurrentTurn.Cname+" do?");
            CombatList.Items.Add("");
            CombatList.Items.Add("Attack");
            CombatList.Items.Add("Skill");
            CombatList.Items.Add("Rune");
        }

        void RuneMenu() {

            CombatList.Items.Add("Back");
            for (int I = 0; I < CurrentTurn.RuneList.Length; I++) {
                if (CurrentTurn.RuneList[I] != null) {
                    Rune CurrentR = CurrentTurn.RuneList[I];
                    CombatList.Items.Add(CurrentR.Name); } }
        }


        void SkillMenu()
        {
            CombatList.Items.Add("Back");
            for (int I = 0; I < CurrentTurn.SkillList.Length; I++)
            {
                if (CurrentTurn.SkillList[I] != null)
                {
                    Skill CurrentS = CurrentTurn.SkillList[I];
                    CombatList.Items.Add(CurrentS.Name);
                }
            }

        }

        private void CombatList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CombatList.SelectedItem == "Attack")
            {
                CombatList.Items.Clear();
                UseAbility("Attack");
            }

            else if (CombatList.SelectedItem == "Skill")
            {
                CombatList.Items.Clear();
                SkillMenu();
            }

            else if (CombatList.SelectedItem == "Rune")
            {
                CombatList.Items.Clear();
                RuneMenu();
            }


            else if (CombatList.SelectedItem == "Back") { CombatList.Items.Clear(); combatMenuOne(); }
            else if (CombatList.SelectedItem == ("")) { }
            else if (CombatList.SelectedItem == ("What will " + CurrentTurn.Cname + " do?")) { }
            else
            {
                UseAbility(CombatList.SelectedItem.ToString());
            }
        }


        private void UseAbility(string Input) {
            CombatList.Items.Clear();
            bool found = true;
            Skill Holder = new Skill();

            if (Input == "Attack") { 
                damage = CurrentTurn.Attack;
                DamageType = "Phy";
                DamageCalc(); }
            else {
               
                for (int I=0;I<SkillList.Length;I++) {
                    if (SkillList[I]!=null) {
                        Skill Hold = SkillList[I];
                        if (Input == Hold.Name) {
                            manacost = Hold.manaCost;
                            found = true;
                            Holder = Hold;
                        } 
                    }
                }

                if (CurrentTurn.Mana >= manacost&&found==true)
                {
                    DamageAttribute = Holder.DamageAttribute;
                    DamageType = Holder.DamageType;

                    if (Holder.DamageType == "Phy")
                    {
                        damage = Holder.Damage * CurrentTurn.Attack;
                        DamageType = "Phy";
                        DamageCalc();
                    }
                    else if (Holder.DamageType == "Mag")
                    {
                        Console.WriteLine("Here2");
                        damage = Holder.Damage * CurrentTurn.SA;
                        DamageType = "Mag";
                        DamageCalc();
                    }
                }


            }
        }

       
        

        private void Mon1HP_Click(object sender, EventArgs e)
        {
            if (Mon1.HP>0&& (CurrentTurn.Cname == Char2.Cname || CurrentTurn.Cname == Char1.Cname || CurrentTurn.Cname == Char3.Cname || CurrentTurn.Cname == Char4.Cname)) {
                Target = Mon1;
                
                Mon1HP.BackColor=(Color.Red);
                Mon2HP.BackColor = (Color.Maroon);
                Mon3HP.BackColor = (Color.Maroon);
                Mon4HP.BackColor = (Color.Maroon);
                Mon5HP.BackColor = (Color.Maroon);
                Mon6HP.BackColor = (Color.Maroon);
                Mon7HP.BackColor = (Color.Maroon);
                Mon8HP.BackColor = (Color.Maroon);
                DamageCalc();

            }
        }

        private void Mon2HP_Click(object sender, EventArgs e)
        {
            if (Mon2.HP > 0 && (CurrentTurn.Cname == Char2.Cname || CurrentTurn.Cname == Char1.Cname || CurrentTurn.Cname == Char3.Cname || CurrentTurn.Cname == Char4.Cname))
            {
                Target = Mon2;

                Mon2HP.BackColor = (Color.Red);
                Mon1HP.BackColor = (Color.Maroon);
                Mon3HP.BackColor = (Color.Maroon);
                Mon4HP.BackColor = (Color.Maroon);
                Mon5HP.BackColor = (Color.Maroon);
                Mon6HP.BackColor = (Color.Maroon); ;
                Mon7HP.BackColor = (Color.Maroon);
                Mon8HP.BackColor = (Color.Maroon);
                DamageCalc();
            }
        }

        private void Mon3HP_Click(object sender, EventArgs e)
        {
            if (Mon3.HP > 0 && (CurrentTurn.Cname == Char2.Cname || CurrentTurn.Cname == Char1.Cname || CurrentTurn.Cname == Char3.Cname || CurrentTurn.Cname == Char4.Cname))
            {
                Target = Mon3;

                Mon3HP.BackColor = (Color.Red);
                Mon2HP.BackColor = (Color.Maroon);
                Mon1HP.BackColor = (Color.Maroon);
                Mon4HP.BackColor = (Color.Maroon);
                Mon5HP.BackColor = (Color.Maroon);
                Mon6HP.BackColor = (Color.Maroon); ;
                Mon7HP.BackColor = (Color.Maroon);
                Mon8HP.BackColor = (Color.Maroon);
                DamageCalc();
            }
        }

        private void Mon4HP_Click(object sender, EventArgs e)
        {
            if (Mon4.HP > 0 && (CurrentTurn.Cname == Char2.Cname || CurrentTurn.Cname == Char1.Cname || CurrentTurn.Cname == Char3.Cname || CurrentTurn.Cname == Char4.Cname))
            {
                Target = Mon3;

                Mon4HP.BackColor = (Color.Red);
                Mon2HP.BackColor = (Color.Maroon);
                Mon3HP.BackColor = (Color.Maroon);
                Mon1HP.BackColor = (Color.Maroon);
                Mon5HP.BackColor = (Color.Maroon);
                Mon6HP.BackColor = (Color.Maroon);
                Mon7HP.BackColor = (Color.Maroon);
                Mon8HP.BackColor = (Color.Maroon);
                DamageCalc();
            }
        }

        private void Mon5HP_Click(object sender, EventArgs e)
        {
            if (Mon5.HP > 0 && (CurrentTurn.Cname == Char2.Cname || CurrentTurn.Cname == Char1.Cname || CurrentTurn.Cname == Char3.Cname || CurrentTurn.Cname == Char4.Cname))
            {
                Target = Mon5;

                Mon5HP.BackColor = (Color.Red);
                Mon2HP.BackColor = (Color.Maroon);
                Mon3HP.BackColor = (Color.Maroon);
                Mon4HP.BackColor = (Color.Maroon);
                Mon1HP.BackColor = (Color.Maroon);
                Mon6HP.BackColor = (Color.Maroon); ;
                Mon7HP.BackColor = (Color.Maroon);
                Mon8HP.BackColor = (Color.Maroon);
                DamageCalc();
            }
        }

        private void Mon6HP_Click(object sender, EventArgs e)
        {
            if (Mon6.HP > 0 && (CurrentTurn.Cname == Char2.Cname || CurrentTurn.Cname == Char1.Cname || CurrentTurn.Cname == Char3.Cname || CurrentTurn.Cname == Char4.Cname))
            {
                Target = Mon6;

                Mon6HP.BackColor = (Color.Red);
                Mon2HP.BackColor = (Color.Maroon);
                Mon3HP.BackColor = (Color.Maroon);
                Mon4HP.BackColor = (Color.Maroon);
                Mon5HP.BackColor = (Color.Maroon);
                Mon1HP.BackColor = (Color.Maroon); ;
                Mon7HP.BackColor = (Color.Maroon);
                Mon8HP.BackColor = (Color.Maroon);
                DamageCalc();
            }
        }

        private void Mon7HP_Click(object sender, EventArgs e)
        {
            if (Mon7.HP > 0 && (CurrentTurn.Cname == Char2.Cname || CurrentTurn.Cname == Char1.Cname || CurrentTurn.Cname == Char3.Cname || CurrentTurn.Cname == Char4.Cname))
            {
                Target = Mon7;

                Mon7HP.BackColor = (Color.Red);
                Mon2HP.BackColor = (Color.Maroon);
                Mon3HP.BackColor = (Color.Maroon);
                Mon4HP.BackColor = (Color.Maroon);
                Mon5HP.BackColor = (Color.Maroon);
                Mon6HP.BackColor = (Color.Maroon); ;
                Mon1HP.BackColor = (Color.Maroon);
                Mon8HP.BackColor = (Color.Maroon);
                DamageCalc();
            }
        }

        private void Mon8HP_Click(object sender, EventArgs e)
        {
            if (Mon8.HP > 0 && (CurrentTurn.Cname == Char2.Cname || CurrentTurn.Cname == Char1.Cname || CurrentTurn.Cname == Char3.Cname || CurrentTurn.Cname == Char4.Cname))
            {
                Target = Mon8;

                Mon8HP.BackColor = (Color.Red);
                Mon2HP.BackColor = (Color.Maroon);
                Mon3HP.BackColor = (Color.Maroon);
                Mon4HP.BackColor = (Color.Maroon);
                Mon5HP.BackColor = (Color.Maroon);
                Mon6HP.BackColor = (Color.Maroon); ;
                Mon7HP.BackColor = (Color.Maroon);
                Mon1HP.BackColor = (Color.Maroon);
                DamageCalc();
            }
        }




        //____________________________________________________________________________________________________________________________________________________________Hiding/Showing
        private void Redraw() {


            Mon8HP.Width = (int)Math.Round((Mon8.HP / Mon8.maxHP) * 140);
            Mon2HP.Width = (int)Math.Round((Mon2.HP / Mon2.maxHP) * 140);
            Mon3HP.Width = (int)Math.Round((Mon3.HP / Mon3.maxHP) * 140);
            Mon4HP.Width = (int)Math.Round((Mon4.HP / Mon4.maxHP) * 140);
            Mon5HP.Width = (int)Math.Round((Mon5.HP / Mon5.maxHP) * 140);
            Mon6HP.Width = (int)Math.Round((Mon6.HP / Mon6.maxHP) * 140);
            Mon7HP.Width = (int)Math.Round((Mon7.HP / Mon7.maxHP) * 140);
            Mon1HP.Width = (int)Math.Round((Mon1.HP / Mon1.maxHP) * 140);
            Char1HP.Width = (int)Math.Round((Char1.HP / Char1.maxHP) * 140);
            Char1Mana.Width = (int)Math.Round((Char1.Mana / Char1.maxMana) * 140);
            Char2HP.Width = (int)Math.Round((Char2.HP / Char2.maxHP) * 140);
            Char2Mana.Width = (int)Math.Round((Char2.Mana / Char2.maxMana) * 140);
            Char3Hp.Width = (int)Math.Round((Char3.HP / Char3.maxHP) * 140);
            Char3Mana.Width = (int)Math.Round((Char3.Mana / Char3.maxMana) * 140);
             Char4hp.Width = (int)Math.Round((Char4.HP / Char4.maxHP) * 140);
            Char4mana.Width = (int)Math.Round((Char4.Mana / Char4.maxMana) * 140);

            Mon6HP.BackColor = (Color.Maroon);
            Mon2HP.BackColor = (Color.Maroon);
            Mon3HP.BackColor = (Color.Maroon);
            Mon4HP.BackColor = (Color.Maroon);
            Mon5HP.BackColor = (Color.Maroon);
            Mon1HP.BackColor = (Color.Maroon); ;
            Mon7HP.BackColor = (Color.Maroon);
            Mon8HP.BackColor = (Color.Maroon);
        }

        void ShowMons(int In)
        {
            int Count = 1;
            if (In == 1) { MonPannel.Left = (((920 * (Count)) / (In + 1)) - 79); MonPannel.Top = ((500 / 3) - 33); MonPannel.Visible = true; Count++; }

            if (In == 2) { MonPannel.Left = (((920 * (Count)) / (In + 1)) - 79); MonPannel.Top = ((500 / 3) - 33); MonPannel.Visible = true; Count++;
                MonPannel2.Left = (((920 * (Count)) / (In + 1)) - 79); MonPannel2.Top = ((500 / 3) - 33); MonPannel2.Visible = true; Count++; }


            if (In == 3)
            {
                MonPannel.Left = (((920 * (Count)) / (In + 1)) - 79); MonPannel.Top = ((500 / 3) - 33); MonPannel.Visible = true; Count++;
                MonPannel2.Left = (((920 * (Count)) / (In + 1)) - 79); MonPannel2.Top = ((500 / 3) - 33); MonPannel2.Visible = true; Count++;
                Monpannel3.Left = (((920 * (Count)) / (In + 1)) - 79); Monpannel3.Top = ((500 / 3) - 33); Monpannel3.Visible = true; Count++;
            }

            if (In == 4)
            {
                MonPannel.Left = (((920 * (Count)) / (In + 1)) - 79); MonPannel.Top = ((500 / 3) - 33); MonPannel.Visible = true; Count++;
                MonPannel2.Left = (((920 * (Count)) / (In + 1)) - 79); MonPannel2.Top = ((500 / 3) - 33); MonPannel2.Visible = true; Count++;
                Monpannel3.Left = (((920 * (Count)) / (In + 1)) - 79); Monpannel3.Top = ((500 / 3) - 33); Monpannel3.Visible = true; Count++;
                Monpannel4.Left = (((920 * (Count)) / (In + 1)) - 79); Monpannel4.Top = ((500 / 3) - 33); Monpannel4.Visible = true; Count = 0;
            }

            if (In == 5)
            {
                MonPannel.Left = (((920 * (Count)) / 5) - 79); MonPannel.Top = ((500 / 3) - 33); MonPannel.Visible = true; Count++;
                MonPannel2.Left = (((920 * (Count)) / 5) - 79); MonPannel2.Top = ((500 / 3) - 33); MonPannel2.Visible = true; Count++;
                Monpannel3.Left = (((920 * (Count)) / 5) - 79); Monpannel3.Top = ((500 / 3) - 33); Monpannel3.Visible = true; Count++;
                Monpannel4.Left = (((920 * (Count)) / 5) - 79); Monpannel4.Top = ((500 / 3) - 33); Monpannel4.Visible = true; Count = 1;

                Monpannel5.Left = (((920 * (Count)) / (In - 3)) - 79); Monpannel5.Top = ((1000 / 3) - 33); Monpannel5.Visible = true; Count++;
            }

            if (In == 6)
            {
                MonPannel.Left = (((920 * (Count)) / 5) - 79); MonPannel.Top = ((500 / 3) - 33); MonPannel.Visible = true; Count++;
                MonPannel2.Left = (((920 * (Count)) / 5) - 79); MonPannel2.Top = ((500 / 3) - 33); MonPannel2.Visible = true; Count++;
                Monpannel3.Left = (((920 * (Count)) / 5) - 79); Monpannel3.Top = ((500 / 3) - 33); Monpannel3.Visible = true; Count++;
                Monpannel4.Left = (((920 * (Count)) / 5) - 79); Monpannel4.Top = ((500 / 3) - 33); Monpannel4.Visible = true; Count = 1;

                Monpannel5.Left = (((920 * (Count)) / (In - 3)) - 79); Monpannel5.Top = ((1000 / 3) - 33); Monpannel5.Visible = true; Count++;
                Monpannel6.Left = (((920 * (Count)) / (In - 3)) - 79); Monpannel6.Top = ((1000 / 3) - 33); Monpannel6.Visible = true; Count++;
            }

            if (In == 7)
            {
                MonPannel.Left = (((920 * (Count)) / 5) - 79); MonPannel.Top = ((500 / 3) - 33); MonPannel.Visible = true; Count++;
                MonPannel2.Left = (((920 * (Count)) / 5) - 79); MonPannel2.Top = ((500 / 3) - 33); MonPannel2.Visible = true; Count++;
                Monpannel3.Left = (((920 * (Count)) / 5) - 79); Monpannel3.Top = ((500 / 3) - 33); Monpannel3.Visible = true; Count++;
                Monpannel4.Left = (((920 * (Count)) / 5) - 79); Monpannel4.Top = ((500 / 3) - 33); Monpannel4.Visible = true; Count = 1;

                Monpannel5.Left = (((920 * (Count)) / (In - 3)) - 79); Monpannel5.Top = ((1000 / 3) - 33); Monpannel5.Visible = true; Count++;
                Monpannel6.Left = (((920 * (Count)) / (In - 3)) - 79); Monpannel6.Top = ((1000 / 3) - 33); Monpannel6.Visible = true; Count++;
                Monpannel7.Left = (((920 * (Count)) / (In - 3)) - 79); Monpannel7.Top = ((1000 / 3) - 33); Monpannel7.Visible = true; Count++;
            }

            if (In == 8)
            {
                MonPannel.Left = (((920 * (Count)) / 5) - 79); MonPannel.Top = ((500 / 3) - 33); MonPannel.Visible = true; Count++;
                MonPannel2.Left = (((920 * (Count)) / 5) - 79); MonPannel2.Top = ((500 / 3) - 33); MonPannel2.Visible = true; Count++;
                Monpannel3.Left = (((920 * (Count)) / 5) - 79); Monpannel3.Top = ((500 / 3) - 33); Monpannel3.Visible = true; Count++;
                Monpannel4.Left = (((920 * (Count)) / 5) - 79); Monpannel4.Top = ((500 / 3) - 33); Monpannel4.Visible = true; Count = 1;

                Monpannel5.Left = (((920 * (Count)) / (In - 3)) - 79); Monpannel5.Top = ((1000 / 3) - 33); Monpannel5.Visible = true; Count++;
                Monpannel6.Left = (((920 * (Count)) / (In - 3)) - 79); Monpannel6.Top = ((1000 / 3) - 33); Monpannel6.Visible = true; Count++;
                Monpannel7.Left = (((920 * (Count)) / (In - 3)) - 79); Monpannel7.Top = ((1000 / 3) - 33); Monpannel7.Visible = true; Count++;
                Monpannel8.Left = (((920 * (Count)) / (In - 3)) - 79); Monpannel8.Top = ((1000 / 3) - 33); Monpannel8.Visible = true; Count++;
            }

        }

        void HideMon()
        {
            MonPannel.Hide();
            MonPannel2.Hide();
            Monpannel3.Hide();
            Monpannel4.Hide();
            Monpannel5.Hide();
            Monpannel6.Hide();
            Monpannel7.Hide();
            Monpannel8.Hide();
            CombatList.Hide();
        }

// ______________________________________________________________________Temp
        private void button1_Click(object sender, EventArgs e)
        {
            Monlist Current = new Monlist();
            Current.Add(Mon1);
            Current.Add(Mon2);
            Battle(Current);
        }
    }

    //________________________________________________________________________________________________________________________Char/mon Details
    public class Character
    {
        public string Cname = "Hello";
        public int Level = 0;
        public String Class = "Human";
      
        public Skill[] SkillList = new Skill[99];
        public Rune[] RuneList = new Rune[99];
     
       
        public int currentXP = 0;
        public int maxXP = 0;

        public double maxHP = 0;
        public double HP = 0;
        public double maxMana = 0;
        public double Mana = 10;
        public int maxAttack = 1;
        public int Attack = 1;
        public int maxSpeed =1;
        public int Speed = 1;
        public int maxSA = 1;
        public int SA = 1;
        public int maxDEF = 1;
        public int DEF =1; 
        public int maxSDF = 1;
        public int SDF = 1;

        public string weakness;
        public string AIType ="AttackOnly"; 


        public void InitiateChar() {
         maxHP = 10;
         HP = 10;
         maxMana = 10;
         Mana = 10;
         maxAttack = 4;
         Attack = 4;
         maxSpeed = 3;
         Speed = 3;
         maxSA = 4;
         SA = 4;
         maxDEF = 1;
         DEF = 1;
         maxSDF = 1;
         SDF = 1;
    }


        public void RestoreChar() { 
            HP = maxHP;
            Mana = maxMana;
            Speed = maxSpeed;
            Attack = maxAttack;
            SA = maxSA;
            DEF = maxDEF;
            SDF = maxSDF;
            
        }

        public void CharRefesh() {
            Speed = maxSpeed;
            Attack = maxAttack;
            SA = maxSA;
            DEF = maxDEF;
            SDF = maxSDF;
        }


        public void GainXp(int Gain) {
            currentXP = +Gain;
            while (currentXP>=maxXP) { 
                currentXP = currentXP-maxXP;
                Level++;
            }
        
        }

    
    }



    public class Monlist {
        public int MonCount = 0;
        public Character[] Monarray = new Character[8];
       

        public void Add(Character Input) {
            Monarray[MonCount] = Input;
            MonCount++;
        }
    }

   //_________________________________________________________________________________________________________________________Skills
    public class Skill {
        public string Name = "Hold";
        public int manaCost = 1;
        public int Damage = 1;
        public string DamageType = "Phy";
        public string DamageAttribute = "Place";
        public string skillType = "Attack";

    
    
    }
    public class Rune {

        public string Name = "Hold";
        public int manaCost = 1;
        public int Damage = 1;
    }



}
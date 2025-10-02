using Core;

namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            RefreshDesertList();
        }

        private void RefreshDesertList()
        {
            listBoxJerboas.Items.Clear();
            var desert = Jerboa.GetDesert();

            if (desert.Count == 0)
            {
                listBoxJerboas.Items.Add("Пустыня пуста (- < -)");
            }

            foreach (var j in desert)
            {
                listBoxJerboas.Items.Add($"ID: {j.Id}  Имя: {j.Name}  Цвет: {j.Color}  " +
                    $"Гладили {j.countOfTouches} раз, Кормили {j.countOfFeedings} раз");
            }
        }

        private void btnAdd_Click( object sender, EventArgs e )
        {
            using (var addForm = new addForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    Jerboa.Make_Jerboa(addForm.JerboaName, addForm.JerboaColor);
                    RefreshDesertList();
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            using (var idForm = new InputIdForm("удалить"))
            {
                if (idForm.ShowDialog() == DialogResult.OK)
                {
                    bool success = Jerboa.Remove_Jerboa(idForm.SelectedId);
                    if (success)
                    {
                        MessageBox.Show("Тушканчик успешно удален (T0T)", "Успех",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshDesertList();
                    }
                    else
                    {
                        MessageBox.Show("Тушканчик с таким ID не найден", "Ошибка",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnPet_Click(object sender, EventArgs e)
        {
            using (var idForm = new InputIdForm("погладить"))
            {
                if (idForm.ShowDialog() == DialogResult.OK)
                {
                    bool success = Jerboa.Pet(idForm.SelectedId);
                    if (success)
                    {
                        MessageBox.Show("Тушканчик поглажен! (^ ^)", "Успех",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshDesertList();
                    }
                    else
                    {
                        MessageBox.Show("Тушканчик с таким ID не найден (T0T)", "Ошибка",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnFeed_Click(object sender, EventArgs e)
        {
            using (var idForm = new InputIdForm("покормить"))
            {
                if (idForm.ShowDialog() == DialogResult.OK)
                {
                    bool success = Jerboa.Feed(idForm.SelectedId);
                    if (success)
                    {
                        MessageBox.Show("Тушканчик покормлен! (^ ^)", "Успех",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshDesertList();
                    }
                    else
                    {
                        MessageBox.Show("Тушканчик с таким ID не найден (T0T)", "Ошибка",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void InitializeComponent()
        {
            label1 = new Label();
            listBoxJerboas = new ListBox();
            btnAdd = new Button();
            btnRemove = new Button();
            btnPet = new Button();
            btnFeed = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(86, 9);
            label1.Name = "label1";
            label1.Size = new Size(483, 25);
            label1.TabIndex = 0;
            label1.Text = "=== ПУСТЫНЯ С ТУШКАНЧИКАМИ ДОСТУПНА ===";
            
            // 
            // listBoxJerboas
            // 
            listBoxJerboas.FormattingEnabled = true;
            listBoxJerboas.ItemHeight = 15;
            listBoxJerboas.Location = new Point(34, 47);
            listBoxJerboas.Name = "listBoxJerboas";
            listBoxJerboas.Size = new Size(473, 244);
            listBoxJerboas.TabIndex = 1;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(525, 79);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(107, 34);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(525, 199);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(107, 34);
            btnRemove.TabIndex = 3;
            btnRemove.Text = "Удалить";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnPet
            // 
            btnPet.Location = new Point(525, 119);
            btnPet.Name = "btnPet";
            btnPet.Size = new Size(107, 34);
            btnPet.TabIndex = 4;
            btnPet.Text = "Погладить";
            btnPet.UseVisualStyleBackColor = true;
            btnPet.Click += btnPet_Click;
            // 
            // btnFeed
            // 
            btnFeed.Location = new Point(525, 159);
            btnFeed.Name = "btnFeed";
            btnFeed.Size = new Size(107, 34);
            btnFeed.TabIndex = 5;
            btnFeed.Text = "Покормить";
            btnFeed.UseVisualStyleBackColor = true;
            btnFeed.Click += btnFeed_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(525, 281);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(107, 34);
            btnExit.TabIndex = 6;
            btnExit.Text = "выйти";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // MainForm
            // 
            ClientSize = new Size(653, 327);
            Controls.Add(btnExit);
            Controls.Add(btnFeed);
            Controls.Add(btnPet);
            Controls.Add(btnRemove);
            Controls.Add(btnAdd);
            Controls.Add(listBoxJerboas);
            Controls.Add(label1);
            Name = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private ListBox listBoxJerboas;
        private Button btnAdd;
        private Button btnRemove;
        private Button btnPet;
        private Button btnFeed;
        private Button btnExit;

        

       
    }
}

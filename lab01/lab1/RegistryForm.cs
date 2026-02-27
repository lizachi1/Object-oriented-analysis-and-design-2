using System;
using System.Drawing;
using System.Windows.Forms;

public partial class RegistryForm : Form
{
    private Label lblStatus;
    private Button btnIssueTicket;
    private ListBox historyBox;

    public RegistryForm(string windowName)
    {
        this.Text = $"Рабочее место: {windowName}";
        this.Size = new Size(300, 400);

        // Инициализация элементов интерфейса
        btnIssueTicket = new Button
        {
            Text = "Выдать талон",
            Dock = DockStyle.Top,
            Height = 50,
            BackColor = Color.LightGreen
        };

        lblStatus = new Label
        {
            Text = "Нажмите для выдачи",
            Dock = DockStyle.Top,
            TextAlign = ContentAlignment.MiddleCenter,
            Height = 40,
            Font = new Font("Arial", 12, FontStyle.Bold)
        };

        historyBox = new ListBox { Dock = DockStyle.Fill };

        // Подписка на событие
        btnIssueTicket.Click += BtnIssueTicket_Click;

        this.Controls.Add(historyBox);
        this.Controls.Add(lblStatus);
        this.Controls.Add(btnIssueTicket);
    }

    private void BtnIssueTicket_Click(object sender, EventArgs e)
    {
        // ОБРАЩЕНИЕ К СИНГЛТОНУ
        // Мы не создаем новый объект, а берем существующий
        QueueManager queue = QueueManager.GetInstance();

        string ticket = queue.GetNextTicket();

        lblStatus.Text = $"Выдан: {ticket}";
        historyBox.Items.Insert(0, $"{DateTime.Now.ToShortTimeString()} - {ticket}");
    }
}
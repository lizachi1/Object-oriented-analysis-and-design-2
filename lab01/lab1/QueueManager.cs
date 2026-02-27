using System;

public sealed class QueueManager
{
    private static QueueManager _instance;
    private static readonly object _lock = new object();

    // Состояние очереди
    private int _currentTicketNumber = 0;

    // Закрываем конструктор
    private QueueManager() { }

    public static QueueManager GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new QueueManager();
                }
            }
        }
        return _instance;
    }

    // Метод выдачи талона (тоже потокобезопасный)
    public string GetNextTicket()
    {
        lock (_lock)
        {
            _currentTicketNumber++;
            return $"ТАЛОН №{_currentTicketNumber:D3}";
        }
    }

    public int GetCurrentCount() => _currentTicketNumber;
}
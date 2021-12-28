using Lab1.GalkinCore.Utils.Atomic;
using System.Collections.Generic;

namespace Lab1.GalkinCore;

public class CasMutex
{
    private readonly AtomicReference<Thread> _lockedThread = new AtomicReference<Thread>(null);
    private readonly SynchronizedCollection<Thread> _threads = new SynchronizedCollection<Thread>();
    public void Lock()
    {
        while (!_lockedThread.CompareAndExchange(Thread.CurrentThread, null))
        {
            Thread.Yield();
        }
    }

    public void Unlock()
    {
        _lockedThread.CompareAndExchange(null, _lockedThread.Value);
    }

    public void Wait()
    {
        var current = Thread.CurrentThread;
        if (_lockedThread.Value != Thread.CurrentThread)
        {
            throw new ThreadStateException();
        }
        _threads.Add(current);
        Unlock();
        while (_threads.Contains(current))
        {
            Thread.Yield();
        }
        Lock();
    }

    public void Notify()
    {
        var current = Thread.CurrentThread;
        if (_lockedThread.Value != current)
        {
            throw new ThreadStateException();
        }

        _threads.Remove(current);
    }

    public void NotifyAll()
    {
        if (_lockedThread.Value != Thread.CurrentThread)
        {
            throw new ThreadStateException();
        }

        _threads.Clear();
    }
}
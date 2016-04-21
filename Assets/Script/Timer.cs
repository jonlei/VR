using UnityEngine;
using Assets.Script;

/// <summary>
/// 计时器
/// </summary>
public class Timer:MonoBehaviour
{
    private float _time = 0;

    private int totalTime;

    private bool _timerAction;

    /// <summary>
    /// 时间结束事件
    /// </summary>
    public TimeOverEvent TimeOverEvent = new TimeOverEvent();


    private static GameObject _timerGo;

    private static Timer _timer;


    public static Timer Instance(TimeOverEvent eventsTimeOverEvent,int time)
    {

            if (_timer == null)
            {
                _timerGo = new GameObject("TimerGo");
                _timer = _timerGo.AddComponent<Timer>();
                _timer.TimeOverEvent = eventsTimeOverEvent;
                _timer.totalTime = time ;
            }

            return _timer;
        //set { throw new System.NotImplementedException(); }
    }

    public static Timer Instance()
    {
        return _timer;
    }
    private Timer()
    {
        
    }

    private void ResetTimer()
    {
        if (_time > 0)
        {
            _time = 0;

            Debug.Log("已初始化计时器" + _time);
        }
    }

    private void Update()
    {
        if (_timerAction)
        {
            if (ActionTime(totalTime))
            {
                TimerOver();

            }
        }

    }
    /// <summary>
    /// 计时开始
    /// </summary>
    public bool ActionTime(int time)
    {
        ResetTimer();
        bool complete = totalTime - (_time += Time.deltaTime) < 0;
        //Debug.Log(totalTime - (_time += Time.deltaTime));
        return complete;

    }


    /// <summary>
    /// 停止计时器
    /// </summary>
    /// <returns></returns>
    public void StopTimer()
    {
        _timerAction = false;
    }

    /// <summary>
    /// 计时结束
    /// </summary>
    public void TimerOver()
    {
        //if (TimeOverEvent.GetPersistentEventCount()>0)
        //{
        //    Debug.Log(TimeOverEvent.GetPersistentEventCount());
        //    TimeOverEvent.Invoke();
           
        //}
        //else
        //{
        //    Debug.Log(TimeOverEvent.GetPersistentEventCount());
        //}
        TimeOverEvent.Invoke();
        _timerAction = false;

    }

}

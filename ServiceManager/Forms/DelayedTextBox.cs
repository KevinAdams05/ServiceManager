using System;
using System.Windows.Forms;

namespace ServiceManager
{
    public class DelayedTextBox : TextBox
    {
        private Timer delayedTextChangedTimer;

        public DelayedTextBox()
        {
            DelayedTextChangedTimeout = 1 * 1000; // 1 second
        }

        public event EventHandler DelayedTextChanged;

        public int DelayedTextChangedTimeout { get; set; }

        protected override void Dispose(bool disposing)
        {
            if (delayedTextChangedTimer != null)
            {
                delayedTextChangedTimer.Stop();
                if (disposing)
                {
                    delayedTextChangedTimer.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        protected virtual void OnDelayedTextChanged(EventArgs e)
        {
            DelayedTextChanged?.Invoke(this, e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            InitializeDelayedTextChangedEvent();
            base.OnTextChanged(e);
        }

        private void InitializeDelayedTextChangedEvent()
        {
            delayedTextChangedTimer?.Stop();

            if (delayedTextChangedTimer == null || delayedTextChangedTimer.Interval != DelayedTextChangedTimeout)
            {
                delayedTextChangedTimer = new Timer();
                delayedTextChangedTimer.Tick += HandleDelayedTextChangedTimerTick;
                delayedTextChangedTimer.Interval = DelayedTextChangedTimeout;
            }

            delayedTextChangedTimer.Start();
        }

        private void HandleDelayedTextChangedTimerTick(object sender, EventArgs e)
        {
            Timer timer = sender as Timer;
            timer?.Stop();

            OnDelayedTextChanged(EventArgs.Empty);
        }
    }
}

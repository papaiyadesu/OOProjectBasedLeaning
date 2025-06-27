namespace OOProjectBasedLeaning
{

    public partial class HomeForm : DragDropForm
    {

        public HomeForm()
        {

            InitializeComponent();
            //•\Ž¦ˆÊ’u‚ÌŽw’è
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(557, 499);

        }

        protected override void OnFormDragEnterSerializable(DragEventArgs dragEventArgs)
        {

            dragEventArgs.Effect = DragDropEffects.Move;

        }

        protected override void OnFormDragDropSerializable(object? serializableObject, DragEventArgs dragEventArgs)
        {

            if (serializableObject is DragDropPanel)
            {

                (serializableObject as DragDropPanel).AddDragDropForm(this, PointToClient(new Point(dragEventArgs.X, dragEventArgs.Y)));

            }

        }
    }

}

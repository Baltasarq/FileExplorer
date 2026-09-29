// (c) 2026 FileExplorer Baltasar MIT License <jbgarcia@uvigo.gal>


namespace FileExplorer.View;


using Avalonia.Controls;


public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        this.LbEntries = this.GetControl<ListBox>( "lbEntries" );
        this.EdDir = this.GetControl<TextBox>( "edDir" );
        this.BtList = this.GetControl<Button>( "btList" );
    }
    
    public ListBox LbEntries { get; }
    public TextBox EdDir { get; }
    public Button BtList { get; }
}

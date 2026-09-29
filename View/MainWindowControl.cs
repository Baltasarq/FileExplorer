// (c) 2026 FileExplorer Baltasar MIT License <jbgarcia@uvigo.gal>


namespace FileExplorer.View;


using FileExplorer.Core;
using System.IO;


public class MainWindowControl {
    public MainWindowControl()
    {
        this.View = new MainWindow();
        
        this.View.BtList.Click += (_, _) => this.OnListFiles();
        this.View.LbEntries.SelectionChanged += (_, _) => this.OnFileSelected();
        this.View.EdDir.Text = DirLister.UserDir;
    }
    
    public MainWindow View { get; }
    
    public void OnListFiles()
    {
        string dir = ( this.View.EdDir.Text ?? "" ).Trim();
        
        this.View.LbEntries.ItemsSource = new DirLister( dir ).Entries;
    }
    
    public void OnFileSelected()
    {
        string fileEntry = (string) this.View.LbEntries.SelectedItem!;
        
        if ( fileEntry != null
          && Directory.Exists( fileEntry ))
        {
            this.View.EdDir.Text = fileEntry;
            this.OnListFiles();
        }
    }
}

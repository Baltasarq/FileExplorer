// (c) FileExplorer Baltasar MIT License <jbgarcia@uvigo.es>


namespace FileExplorer.Core;


using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;


public class DirLister {
    public DirLister(string dir = "")
    {
        this.dir = dir;
        this.secret = $"{Path.DirectorySeparatorChar}.";
        
        if ( string.IsNullOrEmpty( dir ) ) {
            this.dir = UserDir;
        }
    }
    
    public IList<string> Entries {
        get {
            if ( this.entries == null
              || this.entries.Count == 0 )
            {
                this.List();
            }
            
            return new List<string>( this.entries! );
        }
    }
    
    private void List()
    {
        this.entries = new List<string>();
        
        try {
            this.entries.AddRange(
                                Directory.EnumerateFiles(
                                            dir,
                                            "*.*",
                                            SearchOption.TopDirectoryOnly )
                                .Where( fn => !fn.Contains( this.secret )));
            this.entries.AddRange(
                                Directory.EnumerateDirectories(
                                            dir,
                                            "*.*",
                                            SearchOption.TopDirectoryOnly )
                                .Where( fn => !fn.Contains( this.secret )));
        } catch(IOException exc) {
            this.entries.Add( "Error: " + exc.Message );
        }
    }
    
    public static string UserDir { get =>
                            Environment.GetFolderPath(
                                Environment.SpecialFolder.UserProfile );
    }
    
    private string dir;
    private string secret;
    private List<string>? entries;
}

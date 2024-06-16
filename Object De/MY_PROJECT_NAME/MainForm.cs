using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ARC;

namespace ObjectDe {

  public partial class MainForm : ARC.UCForms.FormPluginMaster {

    Configuration _config;

    public MainForm() {

      InitializeComponent();

      // show a config button in the title bar. Set this to false if you do not have a config form.
      ConfigButton = true;
    }

    /// <summary>
    /// Set the configuration from the project file when loaded.
    /// We'll extract the _config class that's from the project file.
    /// </summary>
    public override void SetConfiguration(ARC.Config.Sub.PluginV1 cf) {

      _config = (Configuration)cf.GetCustomObjectV2(typeof(Configuration));

      base.SetConfiguration(cf);
    }

    /// <summary>
    /// When the project is saving, give it a copy of our config
    /// </summary>
    public override ARC.Config.Sub.PluginV1 GetConfiguration() {

      _cf.SetCustomObjectV2(_config);

      return base.GetConfiguration();
    }

    /// <summary>
    /// The user pressed the config button in the title bar. Show the config menu and handle the changes to the config.
    /// </summary>
    public override void ConfigPressed() {

      using (var form = new ConfigForm()) {

        form.SetConfiguration(_config);

        if (form.ShowDialog() != DialogResult.OK)
          return;

        _config = form.GetConfiguration();
      }
    }
  }
}

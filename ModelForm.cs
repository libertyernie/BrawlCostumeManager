using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrawlLib.OpenGL;
using BrawlLib.Modeling;
using BrawlLib.SSBB.ResourceNodes;
using BrawlLib.IO;
using System.IO;

namespace BrawlCostumeManager
{
    class ModelForm : Form
    {
        #region Designer

        private ModelEditControl modelEditControl1;
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModelForm));
            this.modelEditControl1 = new System.Windows.Forms.ModelEditControl();
            this.SuspendLayout();
            // 
            // modelEditControl1
            // 
            this.modelEditControl1.AllowDrop = true;
            this.modelEditControl1.BackColor = System.Drawing.Color.Lavender;
            this.modelEditControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modelEditControl1.Location = new System.Drawing.Point(0, 0);
            this.modelEditControl1.Name = "modelEditControl1";
            this.modelEditControl1.Size = new System.Drawing.Size(639, 528);
            this.modelEditControl1.TabIndex = 0;
            this.modelEditControl1.TargetModelChanged += new System.EventHandler(this.TargetModelChanged);
            // 
            // ModelForm
            // 
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(639, 528);
            this.Controls.Add(this.modelEditControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModelForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModelForm_FormClosing);
            this.ResumeLayout(false);

        }
        #endregion

        public ModelForm() { InitializeComponent(); }

        private List<MDL0Node> _models = new List<MDL0Node>();

        public DialogResult ShowDialog(List<MDL0Node> models) { return ShowDialog(null, models); }
        public DialogResult ShowDialog(IWin32Window owner, List<MDL0Node> models) 
        {
            _models = models;
            ReadSettings();
            try { return base.ShowDialog(owner); }
            finally { _models = null; }
        }
        public DialogResult ShowDialog(MDL0Node model) { return ShowDialog(null, model); }
        public DialogResult ShowDialog(IWin32Window owner, MDL0Node model)
        {
            _models.Add(model);
            ReadSettings();
            try { return ShowDialog(owner); }
            finally { _models = null; }
        }

        public unsafe void ReadSettings()
        {
            if (!File.Exists(Application.StartupPath + "/brawlbox.settings"))
            {
                modelEditControl1.clearSavedSettingsToolStripMenuItem.Enabled = false;
                return;
            }
            FileMap map = FileMap.FromFile(Application.StartupPath + "/brawlbox.settings", FileMapProtect.Read);
            if (*(uint*)map.Address == BBVS.Tag)
            {
                BBVS* settings = (BBVS*)map.Address;

                modelEditControl1.syncAnimationsTogetherToolStripMenuItem.Checked = settings->RetrieveCorrAnims;
                //modelEditControl1._updating = true;
                //modelEditControl1.alwaysSyncFrameCountsToolStripMenuItem.Checked = settings->SyncFCs;
                //modelEditControl1.displayFrameCountDifferencesToolStripMenuItem.Checked = settings->WarnIfFCsDiffer;
                //modelEditControl1._updating = false;
                modelEditControl1.syncLoopToAnimationToolStripMenuItem.Checked = settings->SyncLoopToAnim;
                modelEditControl1.syncTexObjToolStripMenuItem.Checked = settings->SyncTexToObj;
                modelEditControl1.syncObjectsListToVIS0ToolStripMenuItem.Checked = settings->SyncObjToVIS0;
                modelEditControl1.disableBonesWhenPlayingToolStripMenuItem.Checked = settings->DisableBonesOnPlay;

                modelEditControl1.modelPanel1._ambient = settings->amb;
                modelEditControl1.modelPanel1._position = settings->pos;
                modelEditControl1.modelPanel1._diffuse = settings->diff;
                modelEditControl1.modelPanel1._specular = settings->spec;
                modelEditControl1.modelPanel1._defaultTranslate = settings->defaultCam;
                modelEditControl1.modelPanel1._fovY = settings->yFov;
                modelEditControl1.modelPanel1._nearZ = settings->_nearZ;
                modelEditControl1.modelPanel1._farZ = settings->_farz;
                modelEditControl1.modelPanel1.ZoomScale = settings->zScale;
                modelEditControl1.modelPanel1.TranslationScale = settings->tScale;
                modelEditControl1.modelPanel1.RotationScale = settings->rScale;

                if (settings->Maximize)
                    WindowState = FormWindowState.Maximized;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (_models.Count != 0)
            {
                for (int i = 0; i < _models.Count; i++)
                    if (_models[i] != null)
                        modelEditControl1.AppendTarget(_models[i]);
                modelEditControl1.TargetModel = _models[0];
            }
        }

        private void ModelForm_FormClosing(object sender, FormClosingEventArgs e) 
        {
            if (!(e.Cancel = !modelEditControl1.CloseFiles()))
            {
                if (modelEditControl1.TargetModel != null)
                    modelEditControl1.TargetModel = null;

                if (modelEditControl1._targetModels != null)
                    modelEditControl1._targetModels = null;

                modelEditControl1.modelPanel1.ClearAll();
                modelEditControl1.models.Items.Clear();
            }
        }
        private void TargetModelChanged(object sender, EventArgs e)
        {
            if (modelEditControl1.TargetModel != null)
                Text = String.Format("Advanced Model Editor - {0}", modelEditControl1.TargetModel.Name);
            else
                Text = "Advanced Model Editor";
        }
    }
}

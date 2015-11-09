namespace KnowledgeManager
{
    partial class LabelWithCheck
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lb = new System.Windows.Forms.Label();
            this.ck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lb
            // 
            this.lb.AutoSize = true;
            this.lb.BackColor = System.Drawing.Color.Transparent;
            this.lb.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb.Location = new System.Drawing.Point(1, 2);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(56, 17);
            this.lb.TabIndex = 0;
            this.lb.Text = "输入标签";
            // 
            // ck
            // 
            this.ck.AutoSize = true;
            this.ck.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ck.Location = new System.Drawing.Point(56, 4);
            this.ck.Name = "ck";
            this.ck.Size = new System.Drawing.Size(15, 14);
            this.ck.TabIndex = 1;
            this.ck.UseVisualStyleBackColor = true;
            // 
            // LabelWithCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.Controls.Add(this.ck);
            this.Controls.Add(this.lb);
            this.Name = "LabelWithCheck";
            this.Size = new System.Drawing.Size(74, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb;
        private System.Windows.Forms.CheckBox ck;
    }
}

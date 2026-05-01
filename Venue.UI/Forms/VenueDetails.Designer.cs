namespace Venue.UI.Forms
{
    partial class VenueDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            linkLabel5 = new LinkLabel();
            label5 = new Label();
            linkLabel4 = new LinkLabel();
            linkLabel3 = new LinkLabel();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            linkLabel1 = new LinkLabel();
            panel2 = new Panel();
            label6 = new Label();
            panelDetails = new Panel();
            labelVenueLocation = new Label();
            labelVenueAddress = new Label();
            labelVenueEmail = new Label();
            labelVenuePhone = new Label();
            labelVenueDays = new Label();
            labelVenuePrice = new Label();
            labelVenueCapacity = new Label();
            labelVenueReviews = new Label();
            labelVenueRating = new Label();
            labelVenueDescription = new Label();
            labelVenueName = new Label();
            pictureBoxVenue = new PictureBox();
            panelReviews = new Panel();
            buttonAddReview = new Button();
            listBoxReviews = new ListBox();
            labelReviewsHeader = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panelDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxVenue).BeginInit();
            panelReviews.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(64, 0, 0);
            panel1.Controls.Add(linkLabel5);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(linkLabel4);
            panel1.Controls.Add(linkLabel3);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(linkLabel1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(196, 810);
            panel1.TabIndex = 0;
            // 
            // linkLabel5
            // 
            linkLabel5.ActiveLinkColor = Color.IndianRed;
            linkLabel5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel5.ImageAlign = ContentAlignment.TopLeft;
            linkLabel5.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabel5.LinkColor = Color.White;
            linkLabel5.Location = new Point(-1, 348);
            linkLabel5.Name = "linkLabel5";
            linkLabel5.Size = new Size(133, 39);
            linkLabel5.TabIndex = 9;
            linkLabel5.TabStop = true;
            linkLabel5.Text = "👤my profile";
            linkLabel5.TextAlign = ContentAlignment.TopCenter;
            linkLabel5.VisitedLinkColor = Color.White;
            linkLabel5.LinkClicked += linkLabel5_LinkClicked;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.ForeColor = Color.Silver;
            label5.Location = new Point(3, 310);
            label5.Name = "label5";
            label5.Size = new Size(77, 20);
            label5.TabIndex = 8;
            label5.Text = "ACCOUNT";
            // 
            // linkLabel4
            // 
            linkLabel4.ActiveLinkColor = Color.IndianRed;
            linkLabel4.Visible = false;
            linkLabel4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel4.ImageAlign = ContentAlignment.TopLeft;
            linkLabel4.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabel4.LinkColor = Color.White;
            linkLabel4.Location = new Point(1, 255);
            linkLabel4.Name = "linkLabel4";
            linkLabel4.Size = new Size(90, 39);
            linkLabel4.TabIndex = 7;
            linkLabel4.TabStop = true;
            linkLabel4.Text = "👥users";
            linkLabel4.TextAlign = ContentAlignment.TopCenter;
            linkLabel4.VisitedLinkColor = Color.White;
            linkLabel4.LinkClicked += linkLabel4_LinkClicked;
            // 
            // linkLabel3
            // 
            linkLabel3.ActiveLinkColor = Color.IndianRed;
            linkLabel3.Visible = false;
            linkLabel3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel3.ImageAlign = ContentAlignment.TopLeft;
            linkLabel3.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabel3.LinkColor = Color.White;
            linkLabel3.Location = new Point(3, 202);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(133, 39);
            linkLabel3.TabIndex = 6;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "🏛️my venues";
            linkLabel3.TextAlign = ContentAlignment.TopCenter;
            linkLabel3.VisitedLinkColor = Color.White;
            linkLabel3.LinkClicked += linkLabel3_LinkClicked;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.ForeColor = Color.Silver;
            label4.Location = new Point(3, 168);
            label4.Name = "label4";
            label4.Size = new Size(71, 20);
            label4.TabIndex = 5;
            label4.Text = "MANAGE";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.ForeColor = Color.Gold;
            label3.Location = new Point(18, 31);
            label3.Name = "label3";
            label3.Size = new Size(119, 20);
            label3.TabIndex = 3;
            label3.Text = "Wedding Venues";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(17, 5);
            label2.Name = "label2";
            label2.Size = new Size(56, 20);
            label2.TabIndex = 2;
            label2.Text = "Venuè";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.Silver;
            label1.Location = new Point(3, 88);
            label1.Margin = new Padding(100, 125, 100, 125);
            label1.Name = "label1";
            label1.Size = new Size(51, 20);
            label1.TabIndex = 1;
            label1.Text = "MENU";
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = Color.IndianRed;
            linkLabel1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel1.ImageAlign = ContentAlignment.TopLeft;
            linkLabel1.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabel1.LinkColor = Color.White;
            linkLabel1.Location = new Point(3, 129);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(97, 39);
            linkLabel1.TabIndex = 0;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "💒home";
            linkLabel1.TextAlign = ContentAlignment.TopCenter;
            linkLabel1.VisitedLinkColor = Color.White;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(label6);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(196, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1048, 86);
            panel2.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(37, 27);
            label6.Name = "label6";
            label6.Size = new Size(145, 29);
            label6.TabIndex = 0;
            label6.Text = "Venue Details";
            // 
            // panelDetails
            // 
            panelDetails.BackColor = Color.FromArgb(255, 192, 192);
            panelDetails.Controls.Add(labelVenueLocation);
            panelDetails.Controls.Add(labelVenueAddress);
            panelDetails.Controls.Add(labelVenueEmail);
            panelDetails.Controls.Add(labelVenuePhone);
            panelDetails.Controls.Add(labelVenueDays);
            panelDetails.Controls.Add(labelVenuePrice);
            panelDetails.Controls.Add(labelVenueCapacity);
            panelDetails.Controls.Add(labelVenueReviews);
            panelDetails.Controls.Add(labelVenueRating);
            panelDetails.Controls.Add(labelVenueDescription);
            panelDetails.Controls.Add(labelVenueName);
            panelDetails.Controls.Add(pictureBoxVenue);
            panelDetails.Location = new Point(211, 104);
            panelDetails.Name = "panelDetails";
            panelDetails.Size = new Size(1018, 280);
            panelDetails.TabIndex = 2;
            // 
            // labelVenueLocation
            // 
            labelVenueLocation.AutoSize = true;
            labelVenueLocation.ForeColor = Color.DimGray;
            labelVenueLocation.Location = new Point(21, 243);
            labelVenueLocation.Name = "labelVenueLocation";
            labelVenueLocation.Size = new Size(0, 20);
            labelVenueLocation.TabIndex = 11;
            // 
            // labelVenueAddress
            // 
            labelVenueAddress.AutoSize = true;
            labelVenueAddress.ForeColor = Color.DimGray;
            labelVenueAddress.Location = new Point(21, 220);
            labelVenueAddress.Name = "labelVenueAddress";
            labelVenueAddress.Size = new Size(0, 20);
            labelVenueAddress.TabIndex = 10;
            // 
            // labelVenueEmail
            // 
            labelVenueEmail.AutoSize = true;
            labelVenueEmail.ForeColor = Color.DimGray;
            labelVenueEmail.Location = new Point(21, 197);
            labelVenueEmail.Name = "labelVenueEmail";
            labelVenueEmail.Size = new Size(0, 20);
            labelVenueEmail.TabIndex = 9;
            // 
            // labelVenuePhone
            // 
            labelVenuePhone.AutoSize = true;
            labelVenuePhone.ForeColor = Color.DimGray;
            labelVenuePhone.Location = new Point(21, 174);
            labelVenuePhone.Name = "labelVenuePhone";
            labelVenuePhone.Size = new Size(0, 20);
            labelVenuePhone.TabIndex = 8;
            // 
            // labelVenueDays
            // 
            labelVenueDays.AutoSize = true;
            labelVenueDays.ForeColor = Color.DimGray;
            labelVenueDays.Location = new Point(21, 151);
            labelVenueDays.Name = "labelVenueDays";
            labelVenueDays.Size = new Size(0, 20);
            labelVenueDays.TabIndex = 7;
            // 
            // labelVenuePrice
            // 
            labelVenuePrice.AutoSize = true;
            labelVenuePrice.ForeColor = Color.DimGray;
            labelVenuePrice.Location = new Point(21, 128);
            labelVenuePrice.Name = "labelVenuePrice";
            labelVenuePrice.Size = new Size(0, 20);
            labelVenuePrice.TabIndex = 6;
            // 
            // labelVenueCapacity
            // 
            labelVenueCapacity.AutoSize = true;
            labelVenueCapacity.ForeColor = Color.DimGray;
            labelVenueCapacity.Location = new Point(21, 105);
            labelVenueCapacity.Name = "labelVenueCapacity";
            labelVenueCapacity.Size = new Size(0, 20);
            labelVenueCapacity.TabIndex = 5;
            // 
            // labelVenueReviews
            // 
            labelVenueReviews.AutoSize = true;
            labelVenueReviews.BorderStyle = BorderStyle.FixedSingle;
            labelVenueReviews.ForeColor = Color.Firebrick;
            labelVenueReviews.Location = new Point(21, 82);
            labelVenueReviews.Name = "labelVenueReviews";
            labelVenueReviews.Size = new Size(2, 22);
            labelVenueReviews.TabIndex = 4;
            // 
            // labelVenueRating
            // 
            labelVenueRating.AutoSize = true;
            labelVenueRating.ForeColor = Color.Gray;
            labelVenueRating.Location = new Point(21, 59);
            labelVenueRating.Name = "labelVenueRating";
            labelVenueRating.Size = new Size(0, 20);
            labelVenueRating.TabIndex = 3;
            // 
            // labelVenueDescription
            // 
            labelVenueDescription.AutoSize = true;
            labelVenueDescription.ForeColor = Color.Gray;
            labelVenueDescription.Location = new Point(21, 36);
            labelVenueDescription.Name = "labelVenueDescription";
            labelVenueDescription.Size = new Size(0, 20);
            labelVenueDescription.TabIndex = 2;
            // 
            // labelVenueName
            // 
            labelVenueName.AutoSize = true;
            labelVenueName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelVenueName.Location = new Point(21, 10);
            labelVenueName.Name = "labelVenueName";
            labelVenueName.Size = new Size(0, 25);
            labelVenueName.TabIndex = 1;
            // 
            // pictureBoxVenue
            // 
            pictureBoxVenue.Location = new Point(817, 10);
            pictureBoxVenue.Name = "pictureBoxVenue";
            pictureBoxVenue.Size = new Size(186, 157);
            pictureBoxVenue.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxVenue.TabIndex = 0;
            pictureBoxVenue.TabStop = false;
            // 
            // panelReviews
            // 
            panelReviews.BackColor = Color.FromArgb(192, 255, 255);
            panelReviews.Controls.Add(buttonAddReview);
            panelReviews.Controls.Add(listBoxReviews);
            panelReviews.Controls.Add(labelReviewsHeader);
            panelReviews.Location = new Point(211, 400);
            panelReviews.Name = "panelReviews";
            panelReviews.Size = new Size(1018, 392);
            panelReviews.TabIndex = 3;
            // 
            // buttonAddReview
            // 
            buttonAddReview.BackColor = Color.Firebrick;
            buttonAddReview.FlatStyle = FlatStyle.Flat;
            buttonAddReview.ForeColor = Color.White;
            buttonAddReview.Location = new Point(817, 14);
            buttonAddReview.Name = "buttonAddReview";
            buttonAddReview.Size = new Size(186, 40);
            buttonAddReview.TabIndex = 2;
            buttonAddReview.Text = "Add Review";
            buttonAddReview.UseVisualStyleBackColor = false;
            buttonAddReview.Click += buttonAddReview_Click;
            // 
            // listBoxReviews
            // 
            listBoxReviews.FormattingEnabled = true;
            listBoxReviews.HorizontalScrollbar = true;
            listBoxReviews.ItemHeight = 20;
            listBoxReviews.Location = new Point(21, 60);
            listBoxReviews.Name = "listBoxReviews";
            listBoxReviews.Size = new Size(982, 304);
            listBoxReviews.TabIndex = 1;
            // 
            // labelReviewsHeader
            // 
            labelReviewsHeader.AutoSize = true;
            labelReviewsHeader.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelReviewsHeader.Location = new Point(21, 20);
            labelReviewsHeader.Name = "labelReviewsHeader";
            labelReviewsHeader.Size = new Size(89, 25);
            labelReviewsHeader.TabIndex = 0;
            labelReviewsHeader.Text = "Reviews";
            // 
            // VenueDetails
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SeaShell;
            ClientSize = new Size(1244, 810);
            Controls.Add(panelReviews);
            Controls.Add(panelDetails);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            Name = "VenueDetails";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panelDetails.ResumeLayout(false);
            panelDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxVenue).EndInit();
            panelReviews.ResumeLayout(false);
            panelReviews.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private LinkLabel linkLabel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private LinkLabel linkLabel3;
        private Label label4;
        private LinkLabel linkLabel5;
        private Label label5;
        private LinkLabel linkLabel4;
        private Panel panel2;
        private Label label6;
        private Panel panelDetails;
        private PictureBox pictureBoxVenue;
        private Label labelVenueName;
        private Label labelVenueDescription;
        private Label labelVenueRating;
        private Label labelVenueReviews;
        private Label labelVenueCapacity;
        private Label labelVenuePrice;
        private Label labelVenueDays;
        private Label labelVenuePhone;
        private Label labelVenueEmail;
        private Label labelVenueAddress;
        private Label labelVenueLocation;
        private Panel panelReviews;
        private ListBox listBoxReviews;
        private Label labelReviewsHeader;
        private Button buttonAddReview;
    }
}

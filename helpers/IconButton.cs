using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.ComponentModel;


namespace erasmDB
{
    public enum IconType
    {
        NoName = 0x0000,
        Adjust = 0xf042,
        Adn = 0xf170,
        AlignCenter = 0xf037,
        AlignJustify = 0xf039,
        AlignLeft = 0xf036,
        AlignRight = 0xf038,
        Ambulance = 0xf0f9,
        Anchor = 0xf13d,
        Android = 0xf17b,
        AngleDoubleDown = 0xf103,
        AngleDoubleLeft = 0xf100,
        AngleDoubleRight = 0xf101,
        AngleDoubleUp = 0xf102,
        AngleDown = 0xf107,
        AngleLeft = 0xf104,
        AngleRight = 0xf105,
        AngleUp = 0xf106,
        Apple = 0xf179,
        Archive = 0xf187,
        ArrowCircleDown = 0xf0ab,
        ArrowCircleLeft = 0xf0a8,
        ArrowCircleODown = 0xf01a,
        ArrowCircleOLeft = 0xf190,
        ArrowCircleORight = 0xf18e,
        ArrowCircleOUp = 0xf01b,
        ArrowCircleRight = 0xf0a9,
        ArrowCircleUp = 0xf0aa,
        ArrowDown = 0xf063,
        ArrowLeft = 0xf060,
        ArrowRight = 0xf061,
        ArrowUp = 0xf062,
        Arrows = 0xf047,
        ArrowsAlt = 0xf0b2,
        ArrowsH = 0xf07e,
        ArrowsV = 0xf07d,
        Asterisk = 0xf069,
        Automobile = 0xf1b9,
        Backward = 0xf04a,
        Ban = 0xf05e,
        Bank = 0xf19c,
        BarChartO = 0xf080,
        Barcode = 0xf02a,
        Bars = 0xf0c9,
        Beer = 0xf0fc,
        Behance = 0xf1b4,
        BehanceSquare = 0xf1b5,
        Bell = 0xf0f3,
        BellO = 0xf0a2,
        Bitbucket = 0xf171,
        BitbucketSquare = 0xf172,
        Bitcoin = 0xf15a,
        Bold = 0xf032,
        Bolt = 0xf0e7,
        Bomb = 0xf1e2,
        Book = 0xf02d,
        Bookmark = 0xf02e,
        BookmarkO = 0xf097,
        Briefcase = 0xf0b1,
        Btc = 0xf15a,
        Bug = 0xf188,
        Building = 0xf1ad,
        BuildingO = 0xf0f7,
        Bullhorn = 0xf0a1,
        Bullseye = 0xf140,
        Cab = 0xf1ba,
        Calendar = 0xf073,
        CalendarO = 0xf133,
        Camera = 0xf030,
        CameraRetro = 0xf083,
        Car = 0xf1b9,
        CaretDown = 0xf0d7,
        CaretLeft = 0xf0d9,
        CaretRight = 0xf0da,
        CaretSquareODown = 0xf150,
        CaretSquareOLeft = 0xf191,
        CaretSquareORight = 0xf152,
        CaretSquareOUp = 0xf151,
        CaretUp = 0xf0d8,
        Certificate = 0xf0a3,
        Chain = 0xf0c1,
        ChainBroken = 0xf127,
        Check = 0xf00c,
        CheckCircle = 0xf058,
        CheckCircleO = 0xf05d,
        CheckSquare = 0xf14a,
        CheckSquareO = 0xf046,
        ChevronCircleDown = 0xf13a,
        ChevronCircleLeft = 0xf137,
        ChevronCircleRight = 0xf138,
        ChevronCircleUp = 0xf139,
        ChevronDown = 0xf078,
        ChevronLeft = 0xf053,
        ChevronRight = 0xf054,
        ChevronUp = 0xf077,
        Child = 0xf1ae,
        Circle = 0xf111,
        CircleO = 0xf10c,
        CircleONotch = 0xf1ce,
        CircleThin = 0xf1db,
        Clipboard = 0xf0ea,
        ClockO = 0xf017,
        Cloud = 0xf0c2,
        CloudDownload = 0xf0ed,
        CloudUpload = 0xf0ee,
        Cny = 0xf157,
        Code = 0xf121,
        CodeFork = 0xf126,
        Codepen = 0xf1cb,
        Coffee = 0xf0f4,
        Cog = 0xf013,
        Cogs = 0xf085,
        Columns = 0xf0db,
        Comment = 0xf075,
        CommentO = 0xf0e5,
        Comments = 0xf086,
        CommentsO = 0xf0e6,
        Compass = 0xf14e,
        Compress = 0xf066,
        Copy = 0xf0c5,
        CreditCard = 0xf09d,
        Crop = 0xf125,
        Crosshairs = 0xf05b,
        Css3 = 0xf13c,
        Cube = 0xf1b2,
        Cubes = 0xf1b3,
        Cut = 0xf0c4,
        Cutlery = 0xf0f5,
        Dashboard = 0xf0e4,
        Database = 0xf1c0,
        Dedent = 0xf03b,
        Delicious = 0xf1a5,
        Desktop = 0xf108,
        Deviantart = 0xf1bd,
        Digg = 0xf1a6,
        Dollar = 0xf155,
        DotCircleO = 0xf192,
        Download = 0xf019,
        Dribbble = 0xf17d,
        Dropbox = 0xf16b,
        Drupal = 0xf1a9,
        Edit = 0xf044,
        Eject = 0xf052,
        EllipsisH = 0xf141,
        EllipsisV = 0xf142,
        Empire = 0xf1d1,
        Envelope = 0xf0e0,
        EnvelopeO = 0xf003,
        EnvelopeSquare = 0xf199,
        Eraser = 0xf12d,
        Eur = 0xf153,
        Euro = 0xf153,
        Exchange = 0xf0ec,
        Exclamation = 0xf12a,
        ExclamationCircle = 0xf06a,
        ExclamationTriangle = 0xf071,
        Expand = 0xf065,
        ExternalLink = 0xf08e,
        ExternalLinkSquare = 0xf14c,
        Eye = 0xf06e,
        EyeSlash = 0xf070,
        Facebook = 0xf09a,
        FacebookSquare = 0xf082,
        FastBackward = 0xf049,
        FastForward = 0xf050,
        Fax = 0xf1ac,
        Female = 0xf182,
        FighterJet = 0xf0fb,
        File = 0xf15b,
        FileArchiveO = 0xf1c6,
        FileAudioO = 0xf1c7,
        FileCodeO = 0xf1c9,
        FileExcelO = 0xf1c3,
        FileImageO = 0xf1c5,
        FileMovieO = 0xf1c8,
        FileO = 0xf016,
        FilePdfO = 0xf1c1,
        FilePhotoO = 0xf1c5,
        FilePictureO = 0xf1c5,
        FilePowerpointO = 0xf1c4,
        FileSoundO = 0xf1c7,
        FileText = 0xf15c,
        FileTextO = 0xf0f6,
        FileVideoO = 0xf1c8,
        FileWordO = 0xf1c2,
        FileZipO = 0xf1c6,
        FilesO = 0xf0c5,
        Film = 0xf008,
        Filter = 0xf0b0,
        Fire = 0xf06d,
        FireExtinguisher = 0xf134,
        Flag = 0xf024,
        FlagCheckered = 0xf11e,
        FlagO = 0xf11d,
        Flash = 0xf0e7,
        Flask = 0xf0c3,
        Flickr = 0xf16e,
        FloppyO = 0xf0c7,
        Folder = 0xf07b,
        FolderO = 0xf114,
        FolderOpen = 0xf07c,
        FolderOpenO = 0xf115,
        Font = 0xf031,
        Forward = 0xf04e,
        Foursquare = 0xf180,
        FrownO = 0xf119,
        Gamepad = 0xf11b,
        Gavel = 0xf0e3,
        Gbp = 0xf154,
        Ge = 0xf1d1,
        Gear = 0xf013,
        Gears = 0xf085,
        Gift = 0xf06b,
        Git = 0xf1d3,
        GitSquare = 0xf1d2,
        Github = 0xf09b,
        GithubAlt = 0xf113,
        GithubSquare = 0xf092,
        Gittip = 0xf184,
        Glass = 0xf000,
        Globe = 0xf0ac,
        Google = 0xf1a0,
        GooglePlus = 0xf0d5,
        GooglePlusSquare = 0xf0d4,
        GraduationCap = 0xf19d,
        Group = 0xf0c0,
        HSquare = 0xf0fd,
        HackerNews = 0xf1d4,
        HandODown = 0xf0a7,
        HandOLeft = 0xf0a5,
        HandORight = 0xf0a4,
        HandOUp = 0xf0a6,
        HddO = 0xf0a0,
        Header = 0xf1dc,
        Headphones = 0xf025,
        Heart = 0xf004,
        HeartO = 0xf08a,
        History = 0xf1da,
        Home = 0xf015,
        HospitalO = 0xf0f8,
        Html5 = 0xf13b,
        Image = 0xf03e,
        Inbox = 0xf01c,
        Indent = 0xf03c,
        Info = 0xf129,
        InfoCircle = 0xf05a,
        Inr = 0xf156,
        Instagram = 0xf16d,
        Institution = 0xf19c,
        Italic = 0xf033,
        Joomla = 0xf1aa,
        Jpy = 0xf157,
        Jsfiddle = 0xf1cc,
        Key = 0xf084,
        KeyboardO = 0xf11c,
        Krw = 0xf159,
        Language = 0xf1ab,
        Laptop = 0xf109,
        Leaf = 0xf06c,
        Legal = 0xf0e3,
        LemonO = 0xf094,
        LevelDown = 0xf149,
        LevelUp = 0xf148,
        LifeBouy = 0xf1cd,
        LifeRing = 0xf1cd,
        LifeSaver = 0xf1cd,
        LightbulbO = 0xf0eb,
        Link = 0xf0c1,
        Linkedin = 0xf0e1,
        LinkedinSquare = 0xf08c,
        Linux = 0xf17c,
        List = 0xf03a,
        ListAlt = 0xf022,
        ListOl = 0xf0cb,
        ListUl = 0xf0ca,
        LocationArrow = 0xf124,
        Lock = 0xf023,
        LongArrowDown = 0xf175,
        LongArrowLeft = 0xf177,
        LongArrowRight = 0xf178,
        LongArrowUp = 0xf176,
        Magic = 0xf0d0,
        Magnet = 0xf076,
        MailForward = 0xf064,
        MailReply = 0xf112,
        MailReplyAll = 0xf122,
        Male = 0xf183,
        MapMarker = 0xf041,
        Maxcdn = 0xf136,
        Medkit = 0xf0Fa,
        MehO = 0xf11a,
        Microphone = 0xf130,
        MicrophoneSlash = 0xf131,
        Minus = 0xf068,
        MinusCircle = 0xf056,
        MinusSquare = 0xf146,
        MinusSquareO = 0xf147,
        Mobile = 0xf10b,
        MobilePhone = 0xf10b,
        Money = 0xf0d6,
        MoonO = 0xf186,
        MortarBoard = 0xf19d,
        Music = 0xf001,
        Navicon = 0xf0c9,
        Openid = 0xf19b,
        Outdent = 0xf03b,
        Pagelines = 0xf18c,
        PaperPlane = 0xf1d8,
        PaperPlaneO = 0xf1d9,
        Paperclip = 0xf0c6,
        Paragraph = 0xf1dd,
        Paste = 0xf0ea,
        Pause = 0xf04c,
        Paw = 0xf1b0,
        Pencil = 0xf040,
        PencilSquare = 0xf14b,
        PencilSquareO = 0xf044,
        Phone = 0xf095,
        PhoneSquare = 0xf098,
        Photo = 0xf03e,
        PictureO = 0xf03e,
        PiedPiper = 0xf1a7,
        PiedPiperAlt = 0xf1a8,
        PiedPiperSquare = 0xf1a7,
        Pinterest = 0xf0d2,
        PinterestSquare = 0xf0d3,
        Plane = 0xf072,
        Play = 0xf04b,
        PlayCircle = 0xf144,
        PlayCircleO = 0xf01d,
        Plus = 0xf067,
        PlusCircle = 0xf055,
        PlusSquare = 0xf0fe,
        PlusSquareO = 0xf196,
        PowerOff = 0xf011,
        Print = 0xf02f,
        PuzzlePiece = 0xf12e,
        QQ = 0xf1d6,
        Rrcode = 0xf029,
        Ruestion = 0xf128,
        RuestionCircle = 0xf059,
        RuoteLeft = 0xf10d,
        RuoteRight = 0xf10e,
        Ra = 0xf1d0,
        Random = 0xf074,
        Rebel = 0xf1d0,
        Recycle = 0xf1b8,
        Reddit = 0xf1a1,
        RedditSquare = 0xf1a2,
        Refresh = 0xf021,
        Renren = 0xf18b,
        Reorder = 0xf0c9,
        Repeat = 0xf01e,
        Reply = 0xf112,
        ReplyAll = 0xf122,
        Retweet = 0xf079,
        Rmb = 0xf157,
        Road = 0xf018,
        Rocket = 0xf135,
        RotateLeft = 0xf0e2,
        RotateRight = 0xf01e,
        Rouble = 0xf158,
        Rss = 0xf09e,
        RssSquare = 0xf143,
        Rub = 0xf158,
        Ruble = 0xf158,
        Rupee = 0xf156,
        Save = 0xf0c7,
        Scissors = 0xf0c4,
        Search = 0xf002,
        SearchMinus = 0xf010,
        SearchPlus = 0xf00e,
        Send = 0xf1d8,
        SendO = 0xf1d9,
        Share = 0xf064,
        ShareAlt = 0xf1e0,
        ShareAltSquare = 0xf1e1,
        ShareSquare = 0xf14d,
        ShareSquareO = 0xf045,
        Shield = 0xf132,
        ShoppingCart = 0xf07a,
        SignIn = 0xf090,
        SignOut = 0xf08b,
        Signal = 0xf012,
        Sitemap = 0xf0e8,
        Skype = 0xf17e,
        Slack = 0xf198,
        Sliders = 0xf1de,
        SmileO = 0xf118,
        Sort = 0xf0dc,
        SortAlphaAsc = 0xf15d,
        SortAlphaDesc = 0xf15e,
        SortAmountAsc = 0xf160,
        SortAmountDesc = 0xf161,
        SortAsc = 0xf0de,
        SortDesc = 0xf0dd,
        SortDown = 0xf0dd,
        SortNumericAsc = 0xf162,
        SortNumericDesc = 0xf163,
        SortUp = 0xf0de,
        Soundcloud = 0xf1be,
        SpaceShuttle = 0xf197,
        Spinner = 0xf110,
        Spoon = 0xf1b1,
        Spotify = 0xf1bc,
        Square = 0xf0c8,
        SquareO = 0xf096,
        StackExchange = 0xf18d,
        StackOverflow = 0xf16c,
        Star = 0xf005,
        StarHalf = 0xf089,
        StarHalfEmpty = 0xf123,
        StarHalfFull = 0xf123,
        StarHalfO = 0xf123,
        StarO = 0xf006,
        Steam = 0xf1b6,
        SteamSquare = 0xf1b7,
        StepBackward = 0xf048,
        StepForward = 0xf051,
        Stethoscope = 0xf0f1,
        Stop = 0xf04d,
        Strikethrough = 0xf0cc,
        Stumbleupon = 0xf1a4,
        StumbleuponCircle = 0xf1a3,
        Subscript = 0xf12c,
        Suitcase = 0xf0f2,
        SunO = 0xf185,
        Superscript = 0xf12b,
        Support = 0xf1cd,
        Table = 0xf0ce,
        Tablet = 0xf10a,
        Tachometer = 0xf0e4,
        Tag = 0xf02b,
        Tags = 0xf02c,
        Tasks = 0xf0ae,
        Taxi = 0xf1ba,
        TencentWeibo = 0xf1d5,
        Terminal = 0xf120,
        TextHeight = 0xf034,
        TextWidth = 0xf035,
        Th = 0xf00a,
        ThLarge = 0xf009,
        ThList = 0xf00b,
        ThumbTack = 0xf08d,
        ThumbsDown = 0xf165,
        ThumbsODown = 0xf088,
        ThumbsOUp = 0xf087,
        ThumbsUp = 0xf164,
        Ticket = 0xf145,
        Times = 0xf00d,
        TimesCircle = 0xf057,
        TimesCircleO = 0xf05c,
        Tint = 0xf043,
        ToggleDown = 0xf150,
        ToggleLeft = 0xf191,
        ToggleRight = 0xf152,
        ToggleUp = 0xf151,
        TrashO = 0xf014,
        Tree = 0xf1bb,
        Trello = 0xf181,
        Trophy = 0xf091,
        Truck = 0xf0d1,
        Try = 0xf195,
        Tumblr = 0xf173,
        TumblrSquare = 0xf174,
        TurkishLira = 0xf195,
        Twitter = 0xf099,
        TwitterSquare = 0xf081,
        Umbrella = 0xf0e9,
        Underline = 0xf0cd,
        Undo = 0xf0e2,
        University = 0xf19c,
        Unlink = 0xf127,
        Unlock = 0xf09c,
        UnlockAlt = 0xf13e,
        Unsorted = 0xf0dc,
        Upload = 0xf093,
        Usd = 0xf155,
        User = 0xf007,
        UserMd = 0xf0f0,
        Users = 0xf0c0,
        VideoCamera = 0xf03d,
        VimeoSquare = 0xf194,
        Vine = 0xf1ca,
        Vk = 0xf189,
        VolumeDown = 0xf027,
        VolumeOff = 0xf026,
        VolumeUp = 0xf028,
        Warning = 0xf071,
        Wechat = 0xf1d7,
        Weibo = 0xf18a,
        Weixin = 0xf1d7,
        Wheelchair = 0xf193,
        Windows = 0xf17a,
        Won = 0xf159,
        Wordpress = 0xf19a,
        Wrench = 0xf0ad,
        Xing = 0xf168,
        XingSquare = 0xf169,
        Yahoo = 0xf19e,
        Yen = 0xf157,
        Youtube = 0xf167,
        YoutubePlay = 0xf16a,
        YoutubeSquare = 0xf166,
    }

    /// <summary>
    /// Win Forms icon button. Clickable, with hover colour & tooltip.
    /// </summary>
    public class IconButton : PictureBox
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="IconButton" /> class using default values - star icon, normal color = gray, hover color = black.
        /// </summary>
        public IconButton()
            : this(0xf042, 16, Color.DimGray, Color.Black, false, null)
        {
            _autosize = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IconButton" /> class.
        /// </summary>
        /// <param name="type">The icon type.</param>
        /// <param name="size">The size of the icon (number of pixels - 24 creates an icon 24x24px).</param>
        /// <param name="normalColor">Color to use when not hovered over.</param>
        /// <param name="hoverColor">Color to use when hovered over.</param>
        /// <param name="selectable">NOT YET IMPLEMENTED. If set to <c>true</c> the icon will be selectable using the keyboard (tab-key).</param>
        /// <param name="toolTip">The tool tip text to use. Leave as null to not use a tooltip.</param>
        public IconButton(int type, int size, Color normalColor, Color hoverColor, bool selectable, string toolTip)
        {
            IconFont = null;
            BackColor = Color.Transparent;

            // need more than this to make picturebox selectable
            if (selectable)
            {
                SetStyle(ControlStyles.Selectable, true);
                TabStop = true;
            }

            Width = size;
            Height = size;

            IconTypeInt = type;

            InActiveColor = normalColor;
            ActiveColor = hoverColor;

            ToolTipText = toolTip;

            MouseEnter += Icon_MouseEnter;
            MouseLeave += Icon_MouseLeave;
        }

        #endregion

        #region Public

        #region Public Properties

        /// <summary>
        /// Gets or sets the type of the icon to draw.
        /// </summary>
        public int IconTypeInt
        {
            get { return (int)_iconType; }
            set
            {
                _iconType = IconType.NoName;
                try
                {
                    _iconType = (IconType)value;
                }
                catch (Exception ex)
                {

                }

                // see http://fortawesome.github.io/Font-Awesome/cheatsheet/ for a list of hex values
                IconChar = char.ConvertFromUtf32(value);
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the type of the icon to draw.
        /// </summary>
        [Description("font size to caption")]
        public int TextFontSize
        {
            get { return _textFontSize; }
            set
            {
                _textFontSize = value;
                //_text = "-- " + value.ToString();
                TextFont = null;
                Invalidate();
            }
        }

        [Description("Autosize")]
        /// <summary>
        /// Gets or sets the type of the icon to draw.
        /// </summary>
        /// <value>
        /// The tool tip text.
        /// </value>
        public bool AllowAutoSize
        {
            get { return _autosize; }
            set
            {
                _autosize = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the type of the icon to draw.
        /// </summary>
        /// <value>
        /// The tool tip text.
        /// </value>
        public string Caption
        {
            get { return _text; }
            set
            {
                _text = value;
                Invalidate();
            }
        }

        public int CustomMargin
        {
            get { return _margin; }
            set
            {
                _margin = value;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the tool tip text.
        /// </summary>
        /// <value>
        /// The tool tip text.
        /// </value>
        [Localizable(true)]
        public string ToolTipText
        {
            get { return _tooltip; }
            set
            {
                _tooltip = value;
                if (value != null)
                {
                    _tT.IsBalloon = true;
                    _tT.ShowAlways = true;
                    _tT.SetToolTip(this, value);
                }
            }
        }

        /// <summary>
        /// Gets or sets the color when active (hovered over)
        /// </summary>
        public Color ActiveColor
        {
            get { return _activeColor; }
            set
            {
                _activeColor = value;
                ActiveBrush = new SolidBrush(value);
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the color when inactive (not hovered over)
        /// </summary>
        public Color InActiveColor
        {
            get { return _inActiveColor; }
            set
            {
                _inActiveColor = value;
                InActiveBrush = new SolidBrush(value);
                IconBrush = InActiveBrush;
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the control.
        /// </summary>
        /// <returns>The width of the control in pixels.</returns>
        public new int Width
        {
            set
            {
                // force the font size to be recalculated & redrawn
                base.Width = value;
                IconFont = null;
                Invalidate();
            }
            get { return base.Width; }
        }

        /// <summary>
        /// Gets or sets the height of the control.
        /// </summary>
        /// <returns>The height of the control in pixels.</returns>
        [Description("text font")]
        public Font TextFont { get; set; }

        /// <summary>
        /// Gets or sets the height of the control.
        /// </summary>
        /// <returns>The height of the control in pixels.</returns>
        public new int Height
        {
            set
            {
                // force the font size to be recalculated & redrawn
                base.Height = value;
                IconFont = null;
                Invalidate();
            }
            get { return base.Height; }
        }


        private bool _readOnly;
        public bool ReadOnly
        {
            set
            {
                // force the font size to be recalculated & redrawn
                _readOnly = value;
            }
            get { return _readOnly; }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Sets the icon character using a unicode value.
        /// It is recommended the character be set via the IconType property.
        /// </summary>
        /// <param name="newValue">The new value.</param>
        public void SetIconChar(char newValue)
        {
            IconChar = newValue.ToString();
            Invalidate();
        }

        #endregion

        #endregion

        #region Private

        #region Properties & Attributes
        private IconType _iconType = IconType.Star;
        private int _iconTypeInt = 0;
        private Font IconFont { get; set; }
        private int _textFontSize = 12;
        private int _margin = 5;
        private string _text = "";
        private bool _autosize;
        private string _tooltip = null;
        private Color _activeColor = Color.Black;
        private Color _inActiveColor = Color.Black;
        private ToolTip _tT = new ToolTip();
        private string IconChar { get; set; }
        //private Font IconFont { get; set; }
        //private Font TextFont { get; set; }
        private Brush IconBrush { get; set; } // brush currently in use
        private Brush ActiveBrush { get; set; } // brush to use when hovered over
        private Brush InActiveBrush { get; set; } // brush to use when not hovered over
        #endregion

        #region Event Handlers
        protected void Icon_MouseLeave(object sender, EventArgs e)
        {
            // change the brush and force a redraw
            IconBrush = InActiveBrush;
            Invalidate();
        }
        protected void Icon_MouseEnter(object sender, EventArgs e)
        {
            // change the brush and force a redraw
            IconBrush = ActiveBrush;
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;

            // Set best quality
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            // is the font ready to go?
            if (IconFont == null) SetIconFontSize(graphics);
            if (TextFont == null) SetTextFontSize(graphics);

            // Measure string so that we can center the icon.
            SizeF stringSize = graphics.MeasureString(IconChar, IconFont, Width);

            // Measure string so that we can center the icon.
            SizeF stringTextSize = graphics.MeasureString(_text, TextFont, Width);

            float margin = _margin;
            float w = stringSize.Width;
            float h = stringSize.Height;

            float wText = stringTextSize.Width;
            float hText = stringTextSize.Height;

            int newWidth = (int)(2 * margin + w + wText);
            int newHeight = (int)(2 * margin + h + hText);

            if (_autosize && newWidth != Width)
            {
                Width = newWidth;
            }

            // is the font ready to go?
            if (IconFont == null) SetIconFontSize(graphics);
            if (TextFont == null) SetTextFontSize(graphics);


            float left;
            float top;
            float leftText;
            float topText;

            if (Height >= Width)
            {
                // center icon
                left = (Width - w) / 2;
                top = (Height - h) / 2;

                leftText = (Width - wText) / 2;
                topText = (Height - hText);
            }
            else
            {
                left = margin;
                top = (Height - h) / 2;
                leftText = (Width - wText) - margin;
                topText = (Height - hText) / 2;
            }

            if (_text == "")
            {
                left = margin;
                top = margin;
            }
            //if (_text == "" && margin==0)
            //{
            //    Width = newWidth;
            //    Height = newHeight;
            //}

            // Draw string to screen.
            if (IconFont != null) graphics.DrawString(IconChar, IconFont, IconBrush, new PointF(left, top));


            // Draw string to screen.
            if (TextFont != null) graphics.DrawString(_text, TextFont, IconBrush, new PointF(leftText, topText));

            base.OnPaint(e);

            if (Focused)
            {
                var rc = this.ClientRectangle;
                rc.Inflate(-2, -2);
                ControlPaint.DrawFocusRectangle(e.Graphics, rc);
            }


        }
        #endregion

        #region Methods

        /// <summary>
        /// Sets a new font with approprate size for the allocated space.
        /// </summary>
        /// <param name="g">The g.</param>
        private void SetIconFontSize(Graphics g)
        {
            if (Width < Height)
                IconFont = GetAdjustedFont(g, IconChar, Width, Height, 4, true);
            else
                IconFont = GetAdjustedFont(g, IconChar, Height, Width, 4, true);
        }
        private void SetTextFontSize(Graphics g)
        {
            TextFont = new Font("Segoe UI", _textFontSize, FontStyle.Regular);
        }

        /// <summary>
        /// Returns a font instance using the resource icon font.
        /// </summary>
        /// <param name="size">The size of the font in points.</param>
        /// <returns>A new System.Drawing.Font instance</returns>
        private Font GetIconFont(float size)
        {
            return new Font(Fonts.Families[0], size, GraphicsUnit.Point);
        }

        /// <summary>
        /// Returns a new font that fits the specified character into the allocated space.
        /// </summary>
        /// <param name="g">The graphics object.</param>
        /// <param name="graphicString">The string (icon character) to render as a graphic.</param>
        /// <param name="containerWidth">Width of the container.</param>
        /// <param name="maxFontSize">Size of the max font.</param>
        /// <param name="minFontSize">Size of the min font.</param>
        /// <param name="smallestOnFail">if set to <c>true</c> [smallest on fail].</param>
        /// <returns></returns>
        private Font GetAdjustedFont(Graphics g, string graphicString, int containerWidth, int maxFontSize, int minFontSize, bool smallestOnFail)
        {
            for (double adjustedSize = maxFontSize; adjustedSize >= minFontSize; adjustedSize = adjustedSize - 0.5)
            {
                Font testFont = GetIconFont((float)adjustedSize);
                // Test the string with the new size
                SizeF adjustedSizeNew = g.MeasureString(graphicString, testFont);
                if (containerWidth > Convert.ToInt32(adjustedSizeNew.Width))
                {
                    // Fits! return it
                    return testFont;
                }
            }

            // Could not find a font size
            // return min or max or maxFontSize?
            return GetIconFont(smallestOnFail ? minFontSize : maxFontSize);
        }

        #endregion

        #endregion

        #region Static

        /// <summary>
        /// Initializes the <see cref="IconButton" /> class by loading the font from resources upon first use.
        /// </summary>
        static IconButton()
        {
            InitialiseFont();
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
           IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        /// <summary>
        /// Store the icon font in a static variable to reuse between icons
        /// </summary>
        private static readonly PrivateFontCollection Fonts = new PrivateFontCollection();

        /// <summary>
        /// Loads the icon font from the resources.
        /// </summary>
        private static void InitialiseFont()
        {
            try
            {
                unsafe
                {
                    fixed (byte* pFontData = Properties.Resources.fa_solid_900)
                    {
                        uint dummy = 0;
                        //Fonts.AddMemoryFont((IntPtr)pFontData, Properties.Resources.fontawesome_webfont.Length);
                        Fonts.AddMemoryFont((IntPtr)pFontData, Properties.Resources.fa_solid_900.Length);

                        AddFontMemResourceEx((IntPtr)pFontData, (uint)Properties.Resources.fa_solid_900.Length, IntPtr.Zero, ref dummy);
                    }
                }
            }
            catch (Exception ex)
            {
                // log?
            }
        }

        #endregion

    }
}

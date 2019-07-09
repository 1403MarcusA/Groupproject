// このファイルで必要なライブラリのnamespaceを指定
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//ソースツリーテストコメント
/// <summary>
/// プロジェクト名がnamespaceとなります
/// </summary>
namespace Groupshootinggame
{
    /// <summary>
    /// ゲームの基盤となるメインのクラス
    /// 親クラスはXNA.FrameworkのGameクラス
    /// </summary>
    public class Game1 : Game
    {
        // フィールド（このクラスの情報を記述）
        private GraphicsDeviceManager graphicsDeviceManager;//グラフィックスデバイスを管理するオブジェクト
        private SpriteBatch spriteBatch;//画像をスクリーン上に描画するためのオブジェクト


        private Texture2D Player;
        private Vector2 PlayerPos;
        private Vector2 PlayerVelocity;

        private Texture2D Enemy;
        private Vector2 EnemyPos;
        private Vector2 EnemyVelocity;

        private Texture2D Hit;
        private Texture2D Texture;
        private Texture2D Texturell;

        private bool Hitflag = false;
        /// <summary>
        /// コンストラクタ
        /// （new で実体生成された際、一番最初に一回呼び出される）
        /// </summary>
        public Game1()
        {
            //グラフィックスデバイス管理者の実体生成
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            //コンテンツデータ（リソースデータ）のルートフォルダは"Contentに設定
            Content.RootDirectory = "Content";
            graphicsDeviceManager.PreferredBackBufferHeight = 500;
            graphicsDeviceManager.PreferredBackBufferWidth = 500;
        }

        /// <summary>
        /// 初期化処理（起動時、コンストラクタの後に1度だけ呼ばれる）
        /// </summary>
        protected override void Initialize()
        {
            // この下にロジックを記述

            PlayerPos = new Vector2(250, 200);
            PlayerVelocity = Vector2.Zero;
            EnemyPos = new Vector2(250, 150);
            EnemyVelocity = Vector2.Zero;

            // この上にロジックを記述
            base.Initialize();// 親クラスの初期化処理呼び出し。絶対に消すな！！
        }

        /// <summary>
        /// コンテンツデータ（リソースデータ）の読み込み処理
        /// （起動時、１度だけ呼ばれる）
        /// </summary>
        protected override void LoadContent()
        {
            // 画像を描画するために、スプライトバッチオブジェクトの実体生成
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // この下にロジックを記述
            Player = Content.Load<Texture2D>("PlayerTest");
            Enemy = Content.Load<Texture2D>("PlayerTest");
            Hit = Content.Load<Texture2D>("HitTest");

            // この上にロジックを記述
        }

        /// <summary>
        /// コンテンツの解放処理
        /// （コンテンツ管理者以外で読み込んだコンテンツデータを解放）
        /// </summary>
        protected override void UnloadContent()
        {
            // この下にロジックを記述


            // この上にロジックを記述
        }

        /// <summary>
        /// 更新処理
        /// （1/60秒の１フレーム分の更新内容を記述。音再生はここで行う）
        /// </summary>
        /// <param name="gameTime">現在のゲーム時間を提供するオブジェクト</param>
        protected override void Update(GameTime gameTime)
        {
            // ゲーム終了処理（ゲームパッドのBackボタンかキーボードのエスケープボタンが押されたら終了）
            if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) ||
                 (Keyboard.GetState().IsKeyDown(Keys.Escape)))
            {
                Exit();
            }
            PlayerVelocity = Vector2.Zero;
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                PlayerVelocity.Y = 0.5f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                PlayerVelocity.Y = -0.5f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                PlayerVelocity.X = -0.5f;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                PlayerVelocity.X = 0.5f;
            }

            if (PlayerVelocity.Length() != 0)
            {
                PlayerVelocity.Normalize();
            }

            float speed = 2.0f;
            PlayerPos = PlayerPos + PlayerVelocity * speed;


            float PlayerX = PlayerPos.X + 15.0f;
            float PlayerY = PlayerPos.Y + 15.0f;

            float EnemyX = EnemyPos.X + 15.0f;
            float EnemyY = EnemyPos.Y + 15.0f;

            float A = PlayerX - EnemyX;
            float B = PlayerY - EnemyY;
            float C = (A * A) + (B * B);

            if (C <= A + B)
            {
                Hitflag = true;
                Texture = Hit;
                Texturell = Hit;
            }
            else
            {
                Texture = Player;
                Texturell = Enemy;
            }

            // この下に更新ロジックを記述

            // この上にロジックを記述
            base.Update(gameTime); // 親クラスの更新処理呼び出し。絶対に消すな！！
        }

        /// <summary>
        /// 描画処理
        /// </summary>
        /// <param name="gameTime">現在のゲーム時間を提供するオブジェクト</param>
        protected override void Draw(GameTime gameTime)
        {
            // 画面クリア時の色を設定
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // この下に描画ロジックを記述
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, PlayerPos, Color.White);
            spriteBatch.Draw(Texturell, EnemyPos, Color.White);
            spriteBatch.End();

            //この上にロジックを記述
            base.Draw(gameTime); // 親クラスの更新処理呼び出し。絶対に消すな！！
        }
    }
}

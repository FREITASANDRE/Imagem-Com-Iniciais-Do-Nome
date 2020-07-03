 
		public static byte[] GenerateImage(String text) //Enviar o texto para imagem
        {
            Random randomGen = new Random();
            Color color = Color.FromArgb(randomGen.Next(50, 245), randomGen.Next(50, 220), randomGen.Next(100, 210));

            var bmp = new Bitmap(192, 192);
            var sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            var font = new Font("Arial", 72, FontStyle.Bold, GraphicsUnit.Pixel);
            var graphics = Graphics.FromImage(bmp);

            graphics.Clear(Color.Transparent);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            using (Brush b = new SolidBrush(color))
            {
                graphics.FillEllipse(b, new Rectangle(0, 0, 192, 192));
            }
            graphics.DrawString(text, font, new SolidBrush(Color.WhiteSmoke), 95, 100, sf);
            graphics.Flush();

            var ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Png);

            return ms.ToArray(); 
			/*retorna um array que pode ser concatenado com base 64
			 EX: string.Concat("data:image/jpeg;base64,", Convert.ToBase64String(GenerateImage(iniciais)));
			*/

        }
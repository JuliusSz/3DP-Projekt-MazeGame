using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeProjekt
{
    public class Player
    {
        Game game;
        float moveScale = 5f;
        float rotateScale = MathHelper.Pi;
        public Camera camera;
        public Player(Game game)
        {
            this.game = game;
        }
        public void Update(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            KeyboardState keyState = Keyboard.GetState();
            float moveAmount = 0;

            if (keyState.IsKeyDown(Keys.Right))
            {
                camera.Rotation = MathHelper.WrapAngle(camera.Rotation - (rotateScale * elapsed));
                camera.UpdateLookAtHor();
            }

            if (keyState.IsKeyDown(Keys.Left))
            {
                camera.Rotation = MathHelper.WrapAngle(camera.Rotation + (rotateScale * elapsed));
                camera.UpdateLookAtHor();
            }

            if (keyState.IsKeyDown(Keys.W))
            {
                camera.Rotation = MathHelper.WrapAngle(camera.Rotation - (rotateScale * elapsed));
                camera.UpdateLookAtVer();
            }

            if (keyState.IsKeyDown(Keys.S))
            {
                camera.Rotation = MathHelper.WrapAngle(camera.Rotation + (rotateScale * elapsed));
                camera.UpdateLookAtVer();
            }

            if (keyState.IsKeyDown(Keys.Up))
            {
                moveAmount = moveScale * elapsed;
            }

            if (keyState.IsKeyDown(Keys.Down))
            {
                moveAmount = -moveScale * elapsed;
            }
            if (keyState.IsKeyDown(Keys.Space))
            {
                camera.MoveUpward(moveScale * elapsed);
            }
            if (keyState.IsKeyDown(Keys.LeftControl))
            {
                camera.MoveUpward(-moveScale * elapsed);
            }
            if (moveAmount != 0)
            {
                Vector3 newLocation = camera.PreviewMove(moveAmount);
                bool moveOk = true;

                if (newLocation.X < 0 || newLocation.X > Maze.Width)
                    moveOk = false;
                if (newLocation.Z < 0 || newLocation.Z > Maze.Height)
                    moveOk = false;
                if (moveOk)
                    camera.MoveForward(moveAmount);
            }

        }
    }
}

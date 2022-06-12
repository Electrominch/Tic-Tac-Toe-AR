using Leopotam.Ecs.Game.Components;
using Leopotam.Ecs.Game.UI;
using Leopotam.Ecs.Game.UI.Components;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Leopotam.Ecs.Game.UI.Systems
{
    internal class ImageObjectSetupSystem : IEcsRunSystem
    {
        EcsWorld _world = null;
        EcsFilter<ImageObjectComponent, ImageObjectFoundedComponent> _founded = null;
        EcsFilter<GamePlayerComponent, UserComponent> _users = null;
        EcsFilter<GamePlayerComponent, BotComponent> _bots = null;
        CellBehaivor _cellPrefab = null;
        EcsFilter<GameConfComponent> _gi = null;

        public void Run()
        {
            foreach(var foundedIndex in _founded)
            {
                ref var foundedEntity = ref _founded.GetEntity(foundedIndex);//найденная сущность
                ref var imageObjectComponent = ref foundedEntity.Get<ImageObjectComponent>();//компонент трекинг-объекта
                SetupCells(ref imageObjectComponent);
                SetupPlayerViews(imageObjectComponent.View);
                _world.SendMessage(new UpdateAllUIComponent());//обновляем новые клеточки
                _world.SendMessage(new SetRandomBackColorComponent());//случайные цвета для клеточек
                foundedEntity.Del<ImageObjectFoundedComponent>();//снимаем с неё пометку нового объекта
            }
        }

        private void SetupCells(ref ImageObjectComponent imageObjectComponent)
        {
            var gridGroup = imageObjectComponent.View.LayoutGroup;//сетка

            int _cellCount = _gi.Get1(0).CellCount;
            int side = (int)Mathf.Sqrt(_cellCount);

            imageObjectComponent.Cells = new CellBehaivor[side][];
            for (int i = 0; i < imageObjectComponent.Cells.Length; i++)
                imageObjectComponent.Cells[i] = new CellBehaivor[side];

            for (int y = 0; y < side; y++)
                for (int x = 0; x < side; x++)
                {
                    var cell = GameObject.Instantiate(_cellPrefab, gridGroup.transform);
                    cell.X = x;
                    cell.Y = y;
                    imageObjectComponent.Cells[y][x] = cell;
                }
            CalcCellSize(gridGroup);//делаем квадрат из клеточек 
        }

        private void SetupPlayerViews(ImageObjcetView view)
        {
            int playerViewIndex = 0;
            foreach(var i in _users)
            {
                var curPlayerView = view.PlayerViews[playerViewIndex++];
                curPlayerView.IsUserView = true;
                curPlayerView.PlayerID = _users.Get1(i).PlayerID;

                ref var newPlayerViewComponent = ref _world.NewEntity().Get<PlayerViewComponent>();
                newPlayerViewComponent.View = curPlayerView;
                newPlayerViewComponent.ID = curPlayerView.PlayerID;
            }
            foreach (var i in _bots)
            {
                var curPlayerView = view.PlayerViews[playerViewIndex++];
                curPlayerView.IsUserView = false;
                curPlayerView.PlayerID = _bots.Get1(i).PlayerID;

                ref var newPlayerViewComponent = ref _world.NewEntity().Get<PlayerViewComponent>();

                newPlayerViewComponent.View = curPlayerView;
                newPlayerViewComponent.View.SetBotDif(_bots.Get2(i).BotDif);
                newPlayerViewComponent.ID = curPlayerView.PlayerID;
            }
        }

        private void CalcCellSize(GridLayoutGroup gridGroup)
        {
            var rect = gridGroup.GetComponent<RectTransform>().rect;
            var wigth = rect.width - gridGroup.padding.left - gridGroup.padding.right;
            var childCount = gridGroup.transform.childCount;
            var cellSize = wigth / Mathf.Sqrt(childCount);
            gridGroup.cellSize = new Vector2(cellSize, cellSize);
        }
    }
}

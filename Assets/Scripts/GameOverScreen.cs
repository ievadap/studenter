using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public SpriteRenderer Renderer;
    public Sprite Success;
    public Sprite Timer;
    public Sprite NoBook;
    public Sprite CarHit;
    public Sprite BycicleHit;
    public Sprite CatHit;
    public Sprite PidgeonHit;

    public void SetSprite(GameOverType type) {
        switch (type) {
            case GameOverType.FinishWithoutBook: {
                Renderer.sprite = NoBook;
                break;
            }
            case GameOverType.HitByCar: {
                Renderer.sprite = CarHit;
                break;
            }
            case GameOverType.Timer: {
                Renderer.sprite = Timer;
                break;
            }
            case GameOverType.Success: {
                Renderer.sprite = Success;
                break;
            }
            case GameOverType.HitByBiker: {
                Renderer.sprite = BycicleHit;
                break;
            }
            case GameOverType.HitByCat: {
                Renderer.sprite = CatHit;
                break;
            }
            case GameOverType.HitByPidgeon: {
                Renderer.sprite = PidgeonHit;
                break;
            }
            default: {
                Renderer.sprite = Success;
                break;
            }
        }
    }
}

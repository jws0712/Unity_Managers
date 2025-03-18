namespace DesignPetton.FSM
{
    using UnityEngine;

    public interface IBikeState
    {
        void Handle(BikeController controller);
    }

}

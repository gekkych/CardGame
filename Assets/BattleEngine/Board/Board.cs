using System.Collections.Generic;
using UnityEngine;

namespace BattleEngine
{
    public enum CardOwner
    {
        Player,
        Opponent
    }

    public class Board
    {
        public List<Lane> Lanes { get; } = new();
        
        
        private bool MoveCard(int lineIndex, int dx, CardOwner owner)
        {
            Lane line = Lanes[lineIndex];
            var tmp = GetCard(line, owner);
            if (tmp == null) return false;
            
            int length = Lanes.Count;
            int targetIndex = (int)Mathf.Repeat(lineIndex + dx, length);
            Lane targetLine = Lanes[targetIndex];
            
            if (GetCard(targetLine, owner) != null) return false;
            
            SetCard(line, null, owner);
            SetCard(targetLine, tmp, owner);
            return true;
        }

        public bool PlaceCard(Card card, int lineIndex, CardOwner owner)
        {
            Lane line = Lanes[lineIndex];
            if (GetCard(line, owner) != null) return false;
            SetCard(line, card, owner);
            return true;
        }

        public bool RemoveCard(int lineIndex, CardOwner owner)
        {
            Lane line = Lanes[lineIndex];
            if (GetCard(line, owner) == null) return false;
            SetCard(line, null, owner);
            return true;
        }

        public Card GetCard(Lane line, CardOwner owner)
        {
            return owner == CardOwner.Player ? line.PlayerCard : line.OpponentCard;
        }

        public Card GetCard(int id)
        {
            foreach (Lane line in Lanes)
            {
                if (line.PlayerCard.ID == id) return line.PlayerCard;
                if (line.OpponentCard.ID == id) return line.OpponentCard;
            }
            return null;
        }

        private void SetCard(Lane line, Card card, CardOwner owner)
        {
            if (owner == CardOwner.Player)
                line.PlayerCard = card;
            else
                line.OpponentCard = card;
        }
    }
}
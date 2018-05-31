using System;
using System.Collections.Generic;

namespace ShipmentTracker
{
    /// <summary>
    /// Информация о грузе
    /// </summary>
    public class ShipmentInfo
    {
        /// <summary>
        /// Дата приёма
        /// </summary>
        public DateTime Received { get; set; }
        /// <summary>
        /// Планируемая дата отправки
        /// </summary>
        public DateTime Sent { get; set; }
        /// <summary>
        /// Присвоенный код хранения
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Содержимое
        /// </summary>
        public List<Content> Content { get; set; }
        /// <summary>
        /// Хрупкий груз
        /// </summary>
        public bool Fragile { get; set; }
        /// <summary>
        /// Длина
        /// </summary>
        public decimal Length { get; set; }
        /// <summary>
        /// Ширина
        /// </summary>
        public decimal Width { get; set; }
        /// <summary>
        /// Высота
        /// </summary>
        public decimal Height { get; set; }
    }

    public class Content
    {
        /// <summary>
        /// Наименование груза
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Количество
        /// </summary>
        private int _count = 1;

        public int Count
        {
            get => _count;
            set => _count = value;
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", Title, Count);
        }

        public Content Clone()
        {
            return new Content { Title = Title, Count = Count };
        }
    }
}

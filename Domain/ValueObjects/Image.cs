using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects;

public class Image
{
    public int Id { get; set; }
    public byte[] Data { get; set; } = Array.Empty<byte>();
    public string Description { get; set; } = string.Empty;
}

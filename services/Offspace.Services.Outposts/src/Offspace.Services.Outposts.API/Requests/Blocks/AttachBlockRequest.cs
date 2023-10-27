using System.Text.Json.Serialization;

namespace Offspace.Services.Outposts.API.Requests.Blocks;

/// <summary>
///     Represents a request to attach a block to an outpost.
/// </summary>
public sealed record AttachBlockRequest
{
    /// <summary>
    ///     The id of the block to attach.
    /// </summary>
    [FromQueryParams]
    [BindFrom("blockId")]
    public required int BlockId { get; init; }
    
    /// <summary>
    ///     Indicates whether the block is the root block of the outpost.
    /// </summary>
    [FromBody]
    [JsonPropertyName("isRoot")]
    public required bool IsRoot { get; init; }
    
    /// <summary>
    ///     The position of the block in the outpost.
    /// </summary>
    [FromBody]
    [JsonPropertyName("position")]
    public required int Position { get; init; }
    
    /// <summary>
    ///     The id of the outpost to attach the block to.
    /// </summary>
    [FromBody]
    [JsonPropertyName("outpostId")]
    public required int OutpostId { get; init; }
};
using System;
using UnityEngine;

namespace MLAgents
{
    public enum SpaceType
    {
        Discrete,
        Continuous
    }

    /// <summary>
    /// The resolution of a camera used by an agent.
    /// The width defines the number of pixels on the horizontal axis.
    /// The height defines the number of pixels on the verical axis.
    /// blackAndWhite defines whether or not the image is grayscale.
    /// </summary>
    [Serializable]
    public struct Resolution
    {
        /// <summary>The width of the observation in pixels </summary>
        public int width;

        /// <summary>The height of the observation in pixels</summary>
        public int height;

        /// <summary>
        /// If true, the image will be in black and white.
        /// If false, it will be in colors RGB
        /// </summary>
        public bool blackAndWhite;
    }

    /// <summary>
    /// Holds information about the Brain. It defines what are the inputs and outputs of the
    /// decision process.
    /// </summary>
    [Serializable]
    public class BrainParameters
    {
        /// <summary>
        /// If continuous : The length of the float vector that represents
        /// the state
        /// If discrete : The number of possible values the state can take
        /// </summary>
        public int vectorObservationSize = 1;

        [Range(1, 50)] public int numStackedVectorObservations = 1;

        /// <summary>
        /// If continuous : The length of the float vector that represents
        /// the action
        /// If discrete : The number of possible values the action can take*/
        /// </summary>
        public int[] vectorActionSize = new[] {1};

        /// <summary> The list of observation resolutions for the brain</summary>
        public Resolution[] cameraResolutions;

        /// <summary></summary>The list of strings describing what the actions correpond to */
        public string[] vectorActionDescriptions;

        /// <summary>Defines if the action is discrete or continuous</summary>
        public SpaceType vectorActionSpaceType = SpaceType.Discrete;

        /// <summary>
        /// Deep clones the BrainParameter object
        /// </summary>
        /// <returns> A new BrainParameter object with the same values as the original.</returns>
        public BrainParameters Clone()
        {
            return new BrainParameters
            {
                vectorObservationSize = vectorObservationSize,
                numStackedVectorObservations = numStackedVectorObservations,
                vectorActionSize = (int[])vectorActionSize.Clone(),
                cameraResolutions = (Resolution[])cameraResolutions.Clone(),
                vectorActionDescriptions = (string[])vectorActionDescriptions.Clone(),
                vectorActionSpaceType = vectorActionSpaceType
            };
        }
    }
}
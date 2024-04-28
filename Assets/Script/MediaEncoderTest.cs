using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.Collections;
using UnityEditor.Media;
using UnityEngine;

public class MediaEncoderTest
{
    static public void RecordMovie()
    {
        VideoTrackAttributes videoAttr = new VideoTrackAttributes
        {
            frameRate = new MediaRational(50),
            width = 320,
            height = 200,
            includeAlpha = false
        };

        var encodedFilePath = Path.Combine(Application.dataPath, "my_movie.mp4");

        Texture2D tex = new Texture2D((int)videoAttr.width, (int)videoAttr.height, TextureFormat.RGBA32, false);

        using (var encoder = new MediaEncoder(encodedFilePath, videoAttr))
        {
            for (int i = 0; i < 100; ++i)
            {
                // Fill 'tex' with the video content to be encoded into the file for this frame.
                // ...
                encoder.AddFrame(tex);

                // Fill 'audioBuffer' with the audio content to be encoded into the file for this frame.
                // ...
                //encoder.AddSamples(audioBuffer);
            }
            Debug.LogError("导出完成");
            encoder.Dispose();
        }
    }
}

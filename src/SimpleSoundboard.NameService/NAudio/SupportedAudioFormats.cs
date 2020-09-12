using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSoundboard.NameService.NAudio
{
	public static class SupportedAudioFormats
	{
		public const string _3GP = "*.3g2; *.3gp; *.3gp2; *.3gpp;";
		public const string ASF = "*.asf; *.wma; *.wmv;";
		public const string ADTS = "*.aac; *.adts;";
		public const string AVI = "*.avi;";
		public const string MP3 = "*.mp3;";
		public const string MPEG4 = "*.m4a; *.m4v; *.mov; *.mp4;";
		public const string SAMI = "*.sami; *.smi;";
		public const string WAVE = "*.wav";
		public static readonly string CompleteFilter = $"{_3GP} {ASF} {ADTS} {AVI} {MP3} {MPEG4} {SAMI} {WAVE}";
	}
}

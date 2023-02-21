﻿namespace com.muf.fixedmath
{
    public static partial class fixlut
    {
        public static readonly int[] SinCosLut = {
            0, 65536, 804, 65531, 1608, 65516, 2412, 65492, 3216, 65457,
            4019, 65413, 4821, 65358, 5623, 65294, 6424, 65220, 7224, 65137,
            8022, 65043, 8820, 64940, 9616, 64827, 10411, 64704, 11204, 64571,
            11996, 64429, 12785, 64277, 13573, 64115, 14359, 63944, 15143, 63763,
            15924, 63572, 16703, 63372, 17479, 63162, 18253, 62943, 19024, 62714,
            19792, 62476, 20557, 62228, 21320, 61971, 22078, 61705, 22834, 61429,
            23586, 61145, 24335, 60851, 25080, 60547, 25821, 60235, 26558, 59914,
            27291, 59583, 28020, 59244, 28745, 58896, 29466, 58538, 30182, 58172,
            30893, 57798, 31600, 57414, 32303, 57022, 33000, 56621, 33692, 56212,
            34380, 55794, 35062, 55368, 35738, 54934, 36410, 54491, 37076, 54040,
            37736, 53581, 38391, 53114, 39040, 52639, 39683, 52156, 40320, 51665,
            40951, 51166, 41576, 50660, 42194, 50146, 42806, 49624, 43412, 49095,
            44011, 48559, 44604, 48015, 45190, 47464, 45769, 46906, 46341, 46341,
            46906, 45769, 47464, 45190, 48015, 44604, 48559, 44011, 49095, 43412,
            49624, 42806, 50146, 42194, 50660, 41576, 51166, 40951, 51665, 40320,
            52156, 39683, 52639, 39040, 53114, 38391, 53581, 37736, 54040, 37076,
            54491, 36410, 54934, 35738, 55368, 35062, 55794, 34380, 56212, 33692,
            56621, 33000, 57022, 32303, 57414, 31600, 57798, 30893, 58172, 30182,
            58538, 29466, 58896, 28745, 59244, 28020, 59583, 27291, 59914, 26558,
            60235, 25821, 60547, 25080, 60851, 24335, 61145, 23586, 61429, 22834,
            61705, 22078, 61971, 21320, 62228, 20557, 62476, 19792, 62714, 19024,
            62943, 18253, 63162, 17479, 63372, 16703, 63572, 15924, 63763, 15143,
            63944, 14359, 64115, 13573, 64277, 12785, 64429, 11996, 64571, 11204,
            64704, 10411, 64827, 9616, 64940, 8820, 65043, 8022, 65137, 7224,
            65220, 6424, 65294, 5623, 65358, 4821, 65413, 4019, 65457, 3216,
            65492, 2412, 65516, 1608, 65531, 804, 65536, 0, 65531, -804,
            65516, -1608, 65492, -2412, 65457, -3216, 65413, -4019, 65358, -4821,
            65294, -5623, 65220, -6424, 65137, -7224, 65043, -8022, 64940, -8820,
            64827, -9616, 64704, -10411, 64571, -11204, 64429, -11996, 64277, -12785,
            64115, -13573, 63944, -14359, 63763, -15143, 63572, -15924, 63372, -16703,
            63162, -17479, 62943, -18253, 62714, -19024, 62476, -19792, 62228, -20557,
            61971, -21320, 61705, -22078, 61429, -22834, 61145, -23586, 60851, -24335,
            60547, -25080, 60235, -25821, 59914, -26558, 59583, -27291, 59244, -28020,
            58896, -28745, 58538, -29466, 58172, -30182, 57798, -30893, 57414, -31600,
            57022, -32303, 56621, -33000, 56212, -33692, 55794, -34380, 55368, -35062,
            54934, -35738, 54491, -36410, 54040, -37076, 53581, -37736, 53114, -38391,
            52639, -39040, 52156, -39683, 51665, -40320, 51166, -40951, 50660, -41576,
            50146, -42194, 49624, -42806, 49095, -43412, 48559, -44011, 48015, -44604,
            47464, -45190, 46906, -45769, 46341, -46341, 45769, -46906, 45190, -47464,
            44604, -48015, 44011, -48559, 43412, -49095, 42806, -49624, 42194, -50146,
            41576, -50660, 40951, -51166, 40320, -51665, 39683, -52156, 39040, -52639,
            38391, -53114, 37736, -53581, 37076, -54040, 36410, -54491, 35738, -54934,
            35062, -55368, 34380, -55794, 33692, -56212, 33000, -56621, 32303, -57022,
            31600, -57414, 30893, -57798, 30182, -58172, 29466, -58538, 28745, -58896,
            28020, -59244, 27291, -59583, 26558, -59914, 25821, -60235, 25080, -60547,
            24335, -60851, 23586, -61145, 22834, -61429, 22078, -61705, 21320, -61971,
            20557, -62228, 19792, -62476, 19024, -62714, 18253, -62943, 17479, -63162,
            16703, -63372, 15924, -63572, 15143, -63763, 14359, -63944, 13573, -64115,
            12785, -64277, 11996, -64429, 11204, -64571, 10411, -64704, 9616, -64827,
            8820, -64940, 8022, -65043, 7224, -65137, 6424, -65220, 5623, -65294,
            4821, -65358, 4019, -65413, 3216, -65457, 2412, -65492, 1608, -65516,
            804, -65531, 0, -65536, -804, -65531, -1608, -65516, -2412, -65492,
            -3216, -65457, -4019, -65413, -4821, -65358, -5623, -65294, -6424, -65220,
            -7224, -65137, -8022, -65043, -8820, -64940, -9616, -64827, -10411, -64704,
            -11204, -64571, -11996, -64429, -12785, -64277, -13573, -64115, -14359, -63944,
            -15143, -63763, -15924, -63572, -16703, -63372, -17479, -63162, -18253, -62943,
            -19024, -62714, -19792, -62476, -20557, -62228, -21320, -61971, -22078, -61705,
            -22834, -61429, -23586, -61145, -24335, -60851, -25080, -60547, -25821, -60235,
            -26558, -59914, -27291, -59583, -28020, -59244, -28745, -58896, -29466, -58538,
            -30182, -58172, -30893, -57798, -31600, -57414, -32303, -57022, -33000, -56621,
            -33692, -56212, -34380, -55794, -35062, -55368, -35738, -54934, -36410, -54491,
            -37076, -54040, -37736, -53581, -38391, -53114, -39040, -52639, -39683, -52156,
            -40320, -51665, -40951, -51166, -41576, -50660, -42194, -50146, -42806, -49624,
            -43412, -49095, -44011, -48559, -44604, -48015, -45190, -47464, -45769, -46906,
            -46341, -46341, -46906, -45769, -47464, -45190, -48015, -44604, -48559, -44011,
            -49095, -43412, -49624, -42806, -50146, -42194, -50660, -41576, -51166, -40951,
            -51665, -40320, -52156, -39683, -52639, -39040, -53114, -38391, -53581, -37736,
            -54040, -37076, -54491, -36410, -54934, -35738, -55368, -35062, -55794, -34380,
            -56212, -33692, -56621, -33000, -57022, -32303, -57414, -31600, -57798, -30893,
            -58172, -30182, -58538, -29466, -58896, -28745, -59244, -28020, -59583, -27291,
            -59914, -26558, -60235, -25821, -60547, -25080, -60851, -24335, -61145, -23586,
            -61429, -22834, -61705, -22078, -61971, -21320, -62228, -20557, -62476, -19792,
            -62714, -19024, -62943, -18253, -63162, -17479, -63372, -16703, -63572, -15924,
            -63763, -15143, -63944, -14359, -64115, -13573, -64277, -12785, -64429, -11996,
            -64571, -11204, -64704, -10411, -64827, -9616, -64940, -8820, -65043, -8022,
            -65137, -7224, -65220, -6424, -65294, -5623, -65358, -4821, -65413, -4019,
            -65457, -3216, -65492, -2412, -65516, -1608, -65531, -804, -65536, 0,
            -65531, 804, -65516, 1608, -65492, 2412, -65457, 3216, -65413, 4019,
            -65358, 4821, -65294, 5623, -65220, 6424, -65137, 7224, -65043, 8022,
            -64940, 8820, -64827, 9616, -64704, 10411, -64571, 11204, -64429, 11996,
            -64277, 12785, -64115, 13573, -63944, 14359, -63763, 15143, -63572, 15924,
            -63372, 16703, -63162, 17479, -62943, 18253, -62714, 19024, -62476, 19792,
            -62228, 20557, -61971, 21320, -61705, 22078, -61429, 22834, -61145, 23586,
            -60851, 24335, -60547, 25080, -60235, 25821, -59914, 26558, -59583, 27291,
            -59244, 28020, -58896, 28745, -58538, 29466, -58172, 30182, -57798, 30893,
            -57414, 31600, -57022, 32303, -56621, 33000, -56212, 33692, -55794, 34380,
            -55368, 35062, -54934, 35738, -54491, 36410, -54040, 37076, -53581, 37736,
            -53114, 38391, -52639, 39040, -52156, 39683, -51665, 40320, -51166, 40951,
            -50660, 41576, -50146, 42194, -49624, 42806, -49095, 43412, -48559, 44011,
            -48015, 44604, -47464, 45190, -46906, 45769, -46341, 46341, -45769, 46906,
            -45190, 47464, -44604, 48015, -44011, 48559, -43412, 49095, -42806, 49624,
            -42194, 50146, -41576, 50660, -40951, 51166, -40320, 51665, -39683, 52156,
            -39040, 52639, -38391, 53114, -37736, 53581, -37076, 54040, -36410, 54491,
            -35738, 54934, -35062, 55368, -34380, 55794, -33692, 56212, -33000, 56621,
            -32303, 57022, -31600, 57414, -30893, 57798, -30182, 58172, -29466, 58538,
            -28745, 58896, -28020, 59244, -27291, 59583, -26558, 59914, -25821, 60235,
            -25080, 60547, -24335, 60851, -23586, 61145, -22834, 61429, -22078, 61705,
            -21320, 61971, -20557, 62228, -19792, 62476, -19024, 62714, -18253, 62943,
            -17479, 63162, -16703, 63372, -15924, 63572, -15143, 63763, -14359, 63944,
            -13573, 64115, -12785, 64277, -11996, 64429, -11204, 64571, -10411, 64704,
            -9616, 64827, -8820, 64940, -8022, 65043, -7224, 65137, -6424, 65220,
            -5623, 65294, -4821, 65358, -4019, 65413, -3216, 65457, -2412, 65492,
            -1608, 65516, -804, 65531, 0, 65536
        };
    }
}
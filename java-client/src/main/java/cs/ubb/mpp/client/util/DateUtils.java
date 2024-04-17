package cs.ubb.mpp.client.util;

import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

public class DateUtils {
    private static final DateTimeFormatter FORMATTER = DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss.SSSSSSS");

    public static String formatDateTime(LocalDateTime dateTime) {
        return FORMATTER.format(dateTime);
    }

    public static LocalDateTime parse(String str) {
        return LocalDateTime.from(FORMATTER.parse(str));
    }
}
